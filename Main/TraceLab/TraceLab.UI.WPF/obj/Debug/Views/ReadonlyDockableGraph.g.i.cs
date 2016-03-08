﻿#pragma checksum "..\..\..\Views\ReadonlyDockableGraph.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9CB92D1DA82F682BA6E69FA42521FB58"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AvalonDock;
using GraphSharp.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TraceLab.UI.WPF.Commands;
using TraceLab.UI.WPF.Controls;
using TraceLab.UI.WPF.Controls.AdornedControl;
using TraceLab.UI.WPF.Controls.ZoomControl;
using TraceLab.UI.WPF.Converters;
using TraceLab.UI.WPF.ViewModels;
using TraceLab.UI.WPF.Views;
using TraceLab.UI.WPF.Views.Nodes;
using WPFExtensions.AttachedBehaviours;


namespace TraceLab.UI.WPF.Views {
    
    
    /// <summary>
    /// ReadonlyDockableGraph
    /// </summary>
    public partial class ReadonlyDockableGraph : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\Views\ReadonlyDockableGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TraceLab.UI.WPF.Views.ReadonlyDockableGraph ReadOnlyGraphRoot;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\ReadonlyDockableGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TraceLab.UI.WPF.Controls.ZoomControl.ZoomControl zoomControl;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\ReadonlyDockableGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle MarqueeAdorner;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\ReadonlyDockableGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TraceLab.UI.WPF.Controls.NodeGraphLayout graphLayout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TraceLab.UI.WPF;component/views/readonlydockablegraph.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ReadonlyDockableGraph.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ReadOnlyGraphRoot = ((TraceLab.UI.WPF.Views.ReadonlyDockableGraph)(target));
            return;
            case 2:
            
            #line 42 "..\..\..\Views\ReadonlyDockableGraph.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ExecuteToggleLogLevel);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\Views\ReadonlyDockableGraph.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanToggleLogLevel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.zoomControl = ((TraceLab.UI.WPF.Controls.ZoomControl.ZoomControl)(target));
            return;
            case 4:
            this.MarqueeAdorner = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.graphLayout = ((TraceLab.UI.WPF.Controls.NodeGraphLayout)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

