using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _ocrRealTime.Function;
using System.Diagnostics;

namespace _ocrRealTime.ucControl {
    /// <summary>
    /// Interaction logic for ucLiveStream.xaml
    /// </summary>
    public partial class ucLiveStream : UserControl {

        private bool _isOnline {
            get { return myGlobal.testinfo.CameraIsOnline; }
            set {
                myGlobal.testinfo.CameraIsOnline = value;
            }
        }


        public ucLiveStream() {
            InitializeComponent();
            this.DataContext = myGlobal.testinfo;

            //Thread check live stream
            Thread _livestream = new Thread(new ThreadStart(() =>
            {
                while (true) {
                    try {
                        bool ret = Network.PingToIP(myGlobal.defaultsetting.cameraip);

                        if (ret) {
                            if (!_isOnline) {
                                App.Current.Dispatcher.Invoke(new Action(() =>
                                {
                                    _streamPlayerControl.StartPlay(new Uri(myGlobal.defaultsetting.rtsppath));
                                    _isOnline = true;

                                    //Show maskwindow
                                    myGlobal.testinfo.windowwidth = _streamPlayerControl.ActualWidth;
                                    myGlobal.testinfo.windowheight = _streamPlayerControl.ActualHeight;
                                    myGlobal.maskwindow.Show();
                                }));
                            }
                        }
                        else {
                            _isOnline = false;
                        }
                    }
                    catch {
                        _isOnline = false;
                    }
                    Thread.Sleep(1000);
                }
            }));
            _livestream.IsBackground = true;
            _livestream.Start();


            Thread t = new Thread(new ThreadStart(() =>
            {
                while (true) {

                    //Get Rtsp Frame ------------------------------------//
                    if (myGlobal.flags.flagGetRtspFrame == true) {
                        App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        try {
                            myGlobal.bitmapSnapShot = _streamPlayerControl.GetCurrentFrame();
                            Thread.Sleep(100);
                        }
                        catch { }
                        if (myGlobal.bitmapSnapShot != null) myGlobal.flags.flagGetRtspFrame = false;
                    }));
                    }
                    //--------------------------------------------------//
                    Thread.Sleep(250);
                }
            }));
            t.IsBackground = true;
            t.Start();


            Thread _scroll = new Thread(new ThreadStart(() =>
            {
                while (true) {
                    if (_stoptesting == false) {
                        App.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            _scrollViewer.ScrollToEnd();
                        }));
                    }
                    Thread.Sleep(500);
                }
            }));
            _scroll.IsBackground = true;
            _scroll.Start();
        }

        bool _stoptesting = true;
        private void _testButton_Click(object sender, RoutedEventArgs e) {
            _stoptesting = false;
            myGlobal.testinfo.systemlog = "";
            myGlobal.testinfo.statustest = "Waiting...";

            Thread t = new Thread(new ThreadStart(() =>
            {
                int _count = 0;
            REP:
                _count++;
                myGlobal.testinfo.retrytime = string.Format(" Retry : {0}", _count.ToString().PadLeft(6));
                bool ret = _autoTestSharpness();
                //if (ret == false && _stoptesting == false) {
                //    Thread.Sleep(1500);
                //    goto REP;
                //}
                //if (_stoptesting == false) {
                //    Thread.Sleep(1500);
                //    goto REP;
                //}
                myGlobal.testinfo.statustest = ret == true ? "PASS" : "FAIL";
                if (_count < 1000) goto REP; 
            }));
            t.IsBackground = true;
            t.Start();

            Thread _zzz = new Thread(new ThreadStart(() =>
            {
                Stopwatch st = new Stopwatch();
                st.Start();
                while (t.IsAlive) {
                    TimeSpan ts = TimeSpan.FromMilliseconds(st.ElapsedMilliseconds);
                    myGlobal.testinfo.elapsedtime = string.Format("Elapsed time: {0}    ", ts.ToString("hh':'mm':'ss"));
                    Thread.Sleep(100);
                }
                st.Stop();
            }));
            _zzz.IsBackground = true;
            _zzz.Start();
        }



        private void _stopButton_Click(object sender, RoutedEventArgs e) {
            _stoptesting = true;
        }
    }
}
