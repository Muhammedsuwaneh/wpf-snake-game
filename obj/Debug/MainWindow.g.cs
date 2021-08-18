﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "644F489E540A88F955443E301D599880A825B69884EB90123E1C9DFD79BA4706"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SnakeGame;
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


namespace SnakeGame {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding PlayGameCommand;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding PauseGameCommand;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding ContinueGameCommand;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding ResetGameCommand;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding ExitGameCommand;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PlayGame;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PauseGame;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ContinueGame;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ResetGame;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ExitGame;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GameArea;
        
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
            System.Uri resourceLocater = new System.Uri("/SnakeGame;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 8 "..\..\MainWindow.xaml"
            ((SnakeGame.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            ((SnakeGame.MainWindow)(target)).ContentRendered += new System.EventHandler(this.Window_ContentRendered);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PlayGameCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this.PlayGameCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.PlayGameCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 18 "..\..\MainWindow.xaml"
            this.PlayGameCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PlayGameCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PauseGameCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.PauseGameCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.PauseGameCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.PauseGameCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PauseGameCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ContinueGameCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.ContinueGameCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ContinueGameCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.ContinueGameCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ContinueGameCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ResetGameCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.ResetGameCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ResetGameCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this.ResetGameCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ResetGameCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ExitGameCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.ExitGameCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ExitGameCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 22 "..\..\MainWindow.xaml"
            this.ExitGameCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ExitGameCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PlayGame = ((System.Windows.Controls.MenuItem)(target));
            
            #line 33 "..\..\MainWindow.xaml"
            this.PlayGame.Click += new System.Windows.RoutedEventHandler(this.PlayGame_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PauseGame = ((System.Windows.Controls.MenuItem)(target));
            
            #line 34 "..\..\MainWindow.xaml"
            this.PauseGame.Click += new System.Windows.RoutedEventHandler(this.PauseGame_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ContinueGame = ((System.Windows.Controls.MenuItem)(target));
            
            #line 35 "..\..\MainWindow.xaml"
            this.ContinueGame.Click += new System.Windows.RoutedEventHandler(this.ContinueGame_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ResetGame = ((System.Windows.Controls.MenuItem)(target));
            
            #line 36 "..\..\MainWindow.xaml"
            this.ResetGame.Click += new System.Windows.RoutedEventHandler(this.ResetGame_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ExitGame = ((System.Windows.Controls.MenuItem)(target));
            
            #line 37 "..\..\MainWindow.xaml"
            this.ExitGame.Click += new System.Windows.RoutedEventHandler(this.ExitGame_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.GameArea = ((System.Windows.Controls.Canvas)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

