﻿#pragma checksum "..\..\..\UIL\AccountList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "39F0414CEFECBB62B0AABD2C6F4F6AA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
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


namespace AccountManager.UIL {
    
    
    /// <summary>
    /// AccountList
    /// </summary>
    public partial class AccountList : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid accountsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn idAccountColumn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn idUserColumn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn loginColumn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn passwordColumn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn domainColumn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn idCategoryColumn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn siteNameColumn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn descriptionColumn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete_B;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update_B;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UIL\AccountList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemovHash_B;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountManager;component/uil/accountlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UIL\AccountList.xaml"
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
            this.accountsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\..\UIL\AccountList.xaml"
            this.accountsDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.accountsDataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\UIL\AccountList.xaml"
            this.accountsDataGrid.Loaded += new System.Windows.RoutedEventHandler(this.accountsDataGrid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idAccountColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.idUserColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.loginColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.passwordColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.domainColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.idCategoryColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.siteNameColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.descriptionColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.Delete_B = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\UIL\AccountList.xaml"
            this.Delete_B.Click += new System.Windows.RoutedEventHandler(this.Delete_B_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Update_B = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\UIL\AccountList.xaml"
            this.Update_B.Click += new System.Windows.RoutedEventHandler(this.Update_B_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.RemovHash_B = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\UIL\AccountList.xaml"
            this.RemovHash_B.Click += new System.Windows.RoutedEventHandler(this.RemovHash_B_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

