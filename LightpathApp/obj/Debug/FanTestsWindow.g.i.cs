﻿#pragma checksum "..\..\FanTestsWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "92E310510688B50C9CAAE89FD673D792"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace LightpathApp {
    
    
    /// <summary>
    /// FanTestsWindow
    /// </summary>
    public partial class FanTestsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\FanTestsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitFanTests;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\FanTestsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button fanOnTest;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\FanTestsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button fanOffTest;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\FanTestsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button checkFanState;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\FanTestsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image photoPatient;
        
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
            System.Uri resourceLocater = new System.Uri("/LightpathApp;component/fantestswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FanTestsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.exitFanTests = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\FanTestsWindow.xaml"
            this.exitFanTests.Click += new System.Windows.RoutedEventHandler(this.ExitFanTests_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.fanOnTest = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\FanTestsWindow.xaml"
            this.fanOnTest.Click += new System.Windows.RoutedEventHandler(this.FanOnTest_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.fanOffTest = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\FanTestsWindow.xaml"
            this.fanOffTest.Click += new System.Windows.RoutedEventHandler(this.FanOffTest_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.checkFanState = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\FanTestsWindow.xaml"
            this.checkFanState.Click += new System.Windows.RoutedEventHandler(this.CheckFanState_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.photoPatient = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

