﻿// TraceLab - Software Traceability Instrument to Facilitate and Empower Traceability Research
// Copyright (C) 2012-2013 CoEST - National Science Foundation MRI-R2 Grant # CNS: 0959924
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see<http://www.gnu.org/licenses/>.

using System;
using System.Globalization;
using System.Reflection;
using TraceLab.Core.Exceptions;
using TraceLab.Core.Workspaces;
using TraceLabSDK;

namespace TraceLab.Core.Components
{
    /// <summary>
    /// A private class whose job is to load and construct an instance object of a component class - an actual 
    /// object that contains Compute method that is executed during experiment run.
    /// 
    /// ComponentLoader is used when the experiment is being prepared to run.
    /// 
    /// It uses the components metadata and corresponding definition to locate an assembly that must be loaded,
    /// and classname that must be constructed. 
    /// 
    /// Component loader sets the configuration values in the constructed component based on its configuration metadata.
    /// </summary>
    class ComponentLoader : MarshalByRefObject
    {
        private ComponentMetadata m_metadata;
        private IWorkspaceInternal m_workspace;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentLoader"/> class.
        /// 
        /// Note, that this component loader is constructed in the secondary App Domain via CreateInstanceAndUnwrap.
        /// (See LoadComponent method in the ComponentsLibrary).
        /// It is essential that this is done in another App Domain, so that the assembly can be unloaded, after
        /// experiment execution is completed. 
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="workspace">The workspace.</param>
        public ComponentLoader(ComponentMetadata metadata, IWorkspaceInternal workspace)
        {
            m_metadata = metadata;
            m_workspace = workspace;
        }

        /// <summary>
        /// Gets the loaded component. This property holds the constructed component object,
        /// once the Load method is completed
        /// </summary>
        public IComponent LoadedComponent
        {
            get;
            private set;
        }

        /// <summary>
        /// Loads the component based on the provided component metadata. 
        /// </summary>
        /// <param name="logger">The logger - logger provided for the component.</param>
        public void Load(ComponentLogger logger)
        {
            if (LoadedComponent == null)
            {
                Assembly tlcompAssembly = Assembly.LoadFrom(m_metadata.ComponentMetadataDefinition.Assembly);
                Type myLoadClass = tlcompAssembly.GetType(m_metadata.ComponentMetadataDefinition.Classname); // LoadClass is my class

                if (myLoadClass == null)
                {
                    throw new ComponentsLibraryException("Component class " + m_metadata.ComponentMetadataDefinition.Classname + " could not be loaded.");
                }

                LoadedComponent = (IComponent)Activator.CreateInstance(myLoadClass, new Object[] { logger });

                //create workspace wrapper for the component
                IWorkspace workspaceWrapper = WorkspaceWrapperFactory.CreateWorkspaceWrapper(m_metadata, m_workspace);

                LoadedComponent.Workspace = workspaceWrapper;
                SetConfiguration();
            }
        }

        /// <summary>
        /// Sets configuration values. In .Net it sets the properties, in case of java it invokes set methods (since java does not have properties).
        /// </summary>
        private void SetConfiguration()
        {
            if (m_metadata.ComponentMetadataDefinition.ConfigurationType != null)
            {
                try
                {
                    if (m_metadata.ComponentMetadataDefinition.ConfigurationWrapperDefinition.IsJava == false)
                    {
                        PropertyInfo[] properties = LoadedComponent.Configuration.GetType().GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            object value = m_metadata.ConfigWrapper.ConfigValues[property.Name].Value;

                            if (value != null)
                            {
                                var converter = System.ComponentModel.TypeDescriptor.GetConverter(value);

                                //in mono TypeDescriptor.GetConverter(value) does not return EnumValueTypeConverter for EnumValueCollection, 
                                //it returns just simply TypeConverter and that causes experiment to fail with any component that has any enum values
                                if (RuntimeInfo.IsRunInMono)
                                {
                                    var enumValueCollection = value as EnumValueCollection;
                                    if (enumValueCollection != null)
                                    {
                                        converter = new EnumValueTypeConverter(enumValueCollection);
                                    }
                                }

                                if (value.GetType().Equals(property.PropertyType) || property.PropertyType.IsAssignableFrom(value.GetType()))
                                {
                                    property.SetValue(LoadedComponent.Configuration, value, null);
                                }
                                else if (converter != null && converter.CanConvertTo(property.PropertyType))
                                {
                                    property.SetValue(LoadedComponent.Configuration, converter.ConvertTo(value, property.PropertyType), null);
                                }
                                else
                                {
                                    throw new ArgumentException(
                                        string.Format("Unable to convert Configuration value's type {0} to {1}", value.GetType(), property.PropertyType));
                                }
                            }
                        }
                    }
                    else
                    {
                        //for java
                        foreach (string propertyName in m_metadata.ConfigWrapper.ConfigValues.Keys)
                        {
                            String setterPrefix = "set";
                            MethodInfo method = LoadedComponent.Configuration.GetType().GetMethod(setterPrefix + propertyName);
                            if (method != null)
                            {
                                method.Invoke(LoadedComponent.Configuration, new object[] { m_metadata.ConfigWrapper.ConfigValues[propertyName].Value });
                            }
                        }
                    }
                }
                catch (TargetInvocationException ex)
                {
                    //it catches target invocation exception and rethrows inner exception, that we could show user actual message from component exception
                    throw ex.InnerException;
                }
            }
        }
    }
}
