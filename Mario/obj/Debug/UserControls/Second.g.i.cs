﻿#pragma checksum "..\..\..\UserControls\Second.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DB4CA79109754E07D4200EDCDEA6E1D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab5_KPZ.Convertors;
using Lab5_KPZ.UserControls;
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


namespace Lab5_KPZ.UserControls {
    
    
    /// <summary>
    /// Second
    /// </summary>
    public partial class Second : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\UserControls\Second.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextB2;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControls\Second.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Lab5_KPZ.UserControls.RegistrationUserControl RegistrationUserControl;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UserControls\Second.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Lab5_KPZ.UserControls.SignInUserControl SignInUserControl;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserControls\Second.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button submit;
        
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
            System.Uri resourceLocater = new System.Uri("/MarioBros2015;component/usercontrols/second.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\Second.xaml"
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
            this.TextB2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            
            #line 26 "..\..\..\UserControls\Second.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Second_start_playing);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RegistrationUserControl = ((Lab5_KPZ.UserControls.RegistrationUserControl)(target));
            return;
            case 4:
            this.SignInUserControl = ((Lab5_KPZ.UserControls.SignInUserControl)(target));
            return;
            case 5:
            this.submit = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\UserControls\Second.xaml"
            this.submit.Click += new System.Windows.RoutedEventHandler(this.Second_submit_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
