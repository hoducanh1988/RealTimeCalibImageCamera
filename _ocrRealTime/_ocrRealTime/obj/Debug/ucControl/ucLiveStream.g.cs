﻿#pragma checksum "..\..\..\ucControl\ucLiveStream.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3112EA2CAE3CB84AFBEDF86880713BE4C9014A60"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.DataVisualization.Charting;
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
using WebEye.Controls.Wpf.StreamPlayerControl;
using _ocrRealTime.ucControl;


namespace _ocrRealTime.ucControl {
    
    
    /// <summary>
    /// ucLiveStream
    /// </summary>
    public partial class ucLiveStream : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid _GridStream;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem _tbLive;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WebEye.Controls.Wpf.StreamPlayerControl.StreamPlayerControl _streamPlayerControl;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem _tbSys;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer _scrollViewer;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label _lblresult;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart chart1;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\ucControl\ucLiveStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _btnStart;
        
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
            System.Uri resourceLocater = new System.Uri("/realTimeCalibSharpness_Ver1.0.0.0;component/uccontrol/uclivestream.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ucControl\ucLiveStream.xaml"
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
            this._GridStream = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 58 "..\..\..\ucControl\ucLiveStream.xaml"
            ((System.Windows.Controls.TabControl)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this._tbLive = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this._streamPlayerControl = ((WebEye.Controls.Wpf.StreamPlayerControl.StreamPlayerControl)(target));
            return;
            case 5:
            this._tbSys = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this._scrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this._lblresult = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.chart1 = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            case 9:
            this._btnStart = ((System.Windows.Controls.Button)(target));
            
            #line 214 "..\..\..\ucControl\ucLiveStream.xaml"
            this._btnStart.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

