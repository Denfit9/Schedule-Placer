﻿#pragma checksum "..\..\..\..\Windows\addEventsAutoWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05D7BECC70F6954323FBDD043D48E4AB729F13B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CinemaSchedule.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CinemaSchedule.Windows {
    
    
    /// <summary>
    /// addEventsAutoWindow
    /// </summary>
    public partial class addEventsAutoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hoursBegin;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minutesBegin;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hoursEnd;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minutesEnd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CinemaSchedule;component/windows/addeventsautowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.hoursBegin = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.hoursBegin.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.hoursBegin_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.hoursBegin.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.hoursBegin_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 3:
            this.minutesBegin = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.minutesBegin.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.minutesBegin_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.minutesBegin.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.minutesBegin_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 4:
            this.hoursEnd = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.hoursEnd.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.hoursEnd_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.hoursEnd.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.hoursEnd_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 5:
            this.minutesEnd = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.minutesEnd.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.minutesEnd_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\Windows\addEventsAutoWindow.xaml"
            this.minutesEnd.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.minutesEnd_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
