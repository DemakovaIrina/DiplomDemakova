﻿#pragma checksum "..\..\ZanProg.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EF5707F9172A27D3B7A26C494DEB0F83ECE0DC2F57AFFB7E331D2AC054EBFC4D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Sport;
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


namespace Sport {
    
    
    /// <summary>
    /// ZanProg
    /// </summary>
    public partial class ZanProg : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement media1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button playButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pauseButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stopButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider1;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider2;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderback2;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock time;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\ZanProg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LBNameProg;
        
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
            System.Uri resourceLocater = new System.Uri("/Sport;component/zanprog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ZanProg.xaml"
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
            
            #line 8 "..\..\ZanProg.xaml"
            ((Sport.ZanProg)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.media1 = ((System.Windows.Controls.MediaElement)(target));
            
            #line 14 "..\..\ZanProg.xaml"
            this.media1.MediaOpened += new System.Windows.RoutedEventHandler(this.media1_MediaOpened);
            
            #line default
            #line hidden
            return;
            case 3:
            this.playButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ZanProg.xaml"
            this.playButton.Click += new System.Windows.RoutedEventHandler(this.playButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pauseButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\ZanProg.xaml"
            this.pauseButton.Click += new System.Windows.RoutedEventHandler(this.pauseButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stopButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\ZanProg.xaml"
            this.stopButton.Click += new System.Windows.RoutedEventHandler(this.stopButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.slider1 = ((System.Windows.Controls.Slider)(target));
            
            #line 37 "..\..\ZanProg.xaml"
            this.slider1.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slider1_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.slider2 = ((System.Windows.Controls.Slider)(target));
            
            #line 48 "..\..\ZanProg.xaml"
            this.slider2.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slider2_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.sliderback2 = ((System.Windows.Controls.Slider)(target));
            
            #line 49 "..\..\ZanProg.xaml"
            this.sliderback2.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderback2_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.time = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.LBNameProg = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

