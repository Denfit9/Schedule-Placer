﻿#pragma checksum "..\..\..\..\Windows\moveEventWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EC640407B78D8BE8F227C2F787545D1E8A96A21C"
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
    /// MoveEventWindow
    /// </summary>
    public partial class MoveEventWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Windows\moveEventWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hoursEvent;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\moveEventWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minutesEvent;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Windows\moveEventWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox secondsEvent;
        
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
            System.Uri resourceLocater = new System.Uri("/CinemaSchedule;component/windows/moveeventwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\moveEventWindow.xaml"
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
            
            #line 9 "..\..\..\..\Windows\moveEventWindow.xaml"
            ((CinemaSchedule.Windows.MoveEventWindow)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Window_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.hoursEvent = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\..\Windows\moveEventWindow.xaml"
            this.hoursEvent.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.hoursEnd_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\Windows\moveEventWindow.xaml"
            this.hoursEvent.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.hoursEnd_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 3:
            this.minutesEvent = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\..\Windows\moveEventWindow.xaml"
            this.minutesEvent.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.minutesEnd_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\Windows\moveEventWindow.xaml"
            this.minutesEvent.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.minutesEnd_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 4:
            this.secondsEvent = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\Windows\moveEventWindow.xaml"
            this.secondsEvent.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.hoursEnd_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\Windows\moveEventWindow.xaml"
            this.secondsEvent.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.hoursEnd_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 18 "..\..\..\..\Windows\moveEventWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

