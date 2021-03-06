#pragma checksum "..\..\MeneBoxClient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EA4A6094D7C7BB1D010B1EEBE8B2BC0DD4BF8AAAE68A1CAF85226D85A4B1ECB1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using MeneBox;
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


namespace MeneBox {
    
    
    /// <summary>
    /// MeneBoxClient
    /// </summary>
    public partial class MeneBoxClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip User_Logo;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadFile;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Download_File;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete_File;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_testo;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button New_Directory;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Download;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete_Account;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back_Directory;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\MeneBoxClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView File_Directory;
        
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
            System.Uri resourceLocater = new System.Uri("/MeneBox;component/meneboxclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MeneBoxClient.xaml"
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
            
            #line 16 "..\..\MeneBoxClient.xaml"
            ((MeneBox.MeneBoxClient)(target)).Initialized += new System.EventHandler(this.Update);
            
            #line default
            #line hidden
            return;
            case 2:
            this.User_Logo = ((MaterialDesignThemes.Wpf.Chip)(target));
            return;
            case 3:
            this.UploadFile = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MeneBoxClient.xaml"
            this.UploadFile.Click += new System.Windows.RoutedEventHandler(this.BT_Carica_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Download_File = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MeneBoxClient.xaml"
            this.Download_File.Click += new System.Windows.RoutedEventHandler(this.DownloadFile);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Delete_File = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\MeneBoxClient.xaml"
            this.Delete_File.Click += new System.Windows.RoutedEventHandler(this.Delete_File_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BT_testo = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\MeneBoxClient.xaml"
            this.BT_testo.Click += new System.Windows.RoutedEventHandler(this.BT_testo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.New_Directory = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\MeneBoxClient.xaml"
            this.New_Directory.Click += new System.Windows.RoutedEventHandler(this.New_Directory_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Download = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\MeneBoxClient.xaml"
            this.Download.Click += new System.Windows.RoutedEventHandler(this.Download_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\MeneBoxClient.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Delete_Account = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\MeneBoxClient.xaml"
            this.Delete_Account.Click += new System.Windows.RoutedEventHandler(this.Delete_Account_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Back_Directory = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\MeneBoxClient.xaml"
            this.Back_Directory.Click += new System.Windows.RoutedEventHandler(this.GoBack);
            
            #line default
            #line hidden
            return;
            case 12:
            this.File_Directory = ((System.Windows.Controls.ListView)(target));
            
            #line 65 "..\..\MeneBoxClient.xaml"
            this.File_Directory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.File_selected);
            
            #line default
            #line hidden
            
            #line 65 "..\..\MeneBoxClient.xaml"
            this.File_Directory.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DirectoryChange);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

