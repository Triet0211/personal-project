﻿#pragma checksum "..\..\..\WindowProducts.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3CB423F36A0A76ACB739CD53B4E80DC2EAFA0EC1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SalesWPFApp;
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


namespace SalesWPFApp {
    
    
    /// <summary>
    /// WindowProducts
    /// </summary>
    public partial class WindowProducts : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLougout;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewCart;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductNameToSearch;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearchByName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuantity;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddToCart;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\WindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProducts;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SalesWPFApp;V1.0.0.0;component/windowproducts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowProducts.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\WindowProducts.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLougout = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\WindowProducts.xaml"
            this.btnLougout.Click += new System.Windows.RoutedEventHandler(this.btnLougout_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnViewCart = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\WindowProducts.xaml"
            this.btnViewCart.Click += new System.Windows.RoutedEventHandler(this.btnViewCart_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtProductNameToSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnSearchByName = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\WindowProducts.xaml"
            this.btnSearchByName.Click += new System.Windows.RoutedEventHandler(this.btnSearchByName_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtProductName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtQuantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\WindowProducts.xaml"
            this.txtQuantity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAddToCart = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\WindowProducts.xaml"
            this.btnAddToCart.Click += new System.Windows.RoutedEventHandler(this.btnAddToCart_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dgProducts = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\WindowProducts.xaml"
            this.dgProducts.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgProducts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
