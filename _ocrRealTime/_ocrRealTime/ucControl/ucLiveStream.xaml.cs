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
using System.Collections.ObjectModel;

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
            bool _maskIsShow = false;

            //Thread check live stream
            Thread _livestream = new Thread(new ThreadStart(() => {
                while (true) {
                    try {
                        bool ret = Network.PingToIP(myGlobal.defaultsetting.cameraip);

                        if (ret) {
                            if (!_isOnline) {
                                App.Current.Dispatcher.Invoke(new Action(() => {
                                    _streamPlayerControl.StartPlay(new Uri(myGlobal.defaultsetting.rtsppath));
                                    _isOnline = true;

                                    ////Show maskwindow
                                    //myGlobal.testinfo.windowwidth = _streamPlayerControl.ActualWidth;
                                    //myGlobal.testinfo.windowheight = _streamPlayerControl.ActualHeight;
                                    //myGlobal.maskwindow.Show();
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

                    //Show maskwindow
                    if (_maskIsShow == false && _GridStream.ActualWidth > 0 && _GridStream.ActualHeight > 0) {
                        _maskIsShow = true;
                        myGlobal.testinfo.windowwidth = _GridStream.ActualWidth;
                        myGlobal.testinfo.windowheight = _GridStream.ActualHeight;
                        Dispatcher.Invoke(new Action(() => {
                            myGlobal.maskwindow.Width = myGlobal.testinfo.windowwidth;
                            myGlobal.maskwindow.Height = myGlobal.testinfo.windowheight;
                            myGlobal.maskwindow.Show();
                        }));
                    }

                    Thread.Sleep(1000);
                }
            }));
            _livestream.IsBackground = true;
            _livestream.Start();

            Thread t = new Thread(new ThreadStart(() => {
                while (true) {

                    //Get Rtsp Frame ------------------------------------//
                    if (_isOnline == true) {
                        if (myGlobal.flags.flagGetRtspFrame == true) {
                            App.Current.Dispatcher.Invoke(new Action(() => {
                                try {
                                    myGlobal.bitmapSnapShot = _streamPlayerControl.GetCurrentFrame();
                                    Thread.Sleep(100);
                                }
                                catch { }
                                if (myGlobal.bitmapSnapShot != null) myGlobal.flags.flagGetRtspFrame = false;
                            }));
                        }
                    }
                    //--------------------------------------------------//
                    Thread.Sleep(250);
                }
            }));
            t.IsBackground = true;
            t.Start();


            //Thread _scroll = new Thread(new ThreadStart(() =>
            //{
            //    while (true) {
            //        if (_stoptesting == false) {
            //            App.Current.Dispatcher.Invoke(new Action(() =>
            //            {
            //                _scrollViewer.ScrollToEnd();
            //            }));
            //        }
            //        Thread.Sleep(500);
            //    }
            //}));
            //_scroll.IsBackground = true;
            //_scroll.Start();

            Thread _calmaster = new Thread(new ThreadStart(() => {
                while (true) {
                    if (myGlobal.isCalculateStandardValue == true) {
                        Dispatcher.Invoke(new Action(() => {
                            if (!_isOnline) {
                                myGlobal.isCalculateStandardValue = false;
                                MessageBox.Show("Camera is not online.\r\nPlease check again.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            _btnStart.Content = "Stop Test";
                            _btnStart.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#E6D5BD");

                            myGlobal.testinfo.systemlog = "";
                            myGlobal.testinfo.statustest = "Waiting...";
                            _stoptesting = false;
                            chartData.Clear();
                            x = 0;
                            minY = double.MaxValue;
                            maxY = double.MinValue;

                            Thread _ttt = new Thread(new ThreadStart(() => {
                                int _count = 0;
                            REP:
                                _count++;
                                myGlobal.testinfo.retrytime = string.Format("Test time: {0}", _count.ToString().PadLeft(6));
                                myGlobal.testinfo.testtime = _count.ToString();
                                bool ret = _autoTestSharpness();

                                Dispatcher.Invoke(new Action(() => {
                                    AddChartData(double.Parse(myGlobal.testinfo.coefficient));

                                    if (double.Parse(myGlobal.testinfo.coefficient) < minY) {
                                        minY = double.Parse(myGlobal.testinfo.coefficient);
                                    }
                                    if (double.Parse(myGlobal.testinfo.coefficient) > maxY) {
                                        maxY = double.Parse(myGlobal.testinfo.coefficient);
                                    }

                                    ChartTitle = string.Format("Min value = {0}, Max value = {1}", minY, maxY);
                                }));

                                myGlobal.testinfo.statustest = ret == true ? "PASS" : "FAIL";
                                if (_count < 100) goto REP;
                                else {
                                    Dispatcher.Invoke(new Action(() => {
                                        _btnStart.Content = "Auto Test";
                                        _btnStart.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#CC821C");
                                        if (MessageBox.Show(string.Format("Calculated standard value = {0}\n---------------------------\nDo you want to save this value to setting?\nClick YES = save\nClick NO = cancel.", minY), "Message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                                            myGlobal.defaultsetting.standardvalue = minY.ToString();
                                            myGlobal.defaultsetting.SaveSetting();
                                            MessageBox.Show("Standard value saved success.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                                        }
                                    }));
                                    myGlobal.isCalculateStandardValue = false;
                                    return;
                                }
                            }));
                            _ttt.IsBackground = true;
                            _ttt.Start();

                            Thread _zzz = new Thread(new ThreadStart(() => {
                                Stopwatch st = new Stopwatch();
                                st.Start();
                                while (_ttt.IsAlive) {
                                    TimeSpan ts = TimeSpan.FromMilliseconds(st.ElapsedMilliseconds);
                                    myGlobal.testinfo.elapsedtime = string.Format("Elapsed time: {0}    ", ts.ToString("hh':'mm':'ss"));
                                    Thread.Sleep(100);
                                }
                                st.Stop();
                            }));
                            _zzz.IsBackground = true;
                            _zzz.Start();
                            myGlobal.isCalculateStandardValue = false;
                        }));
                    }
                    else Thread.Sleep(1000);
                }
            }));
            _calmaster.IsBackground = true;
            _calmaster.Start();


            chart1.DataContext = this;
            chartData = new ObservableCollection<ChartData>();

        }

        bool _stoptesting = false;

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            switch (b.Content.ToString()) {
                case "Auto Test": {
                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
                        //CHECK CAMERA ONLINE OR NOT
                        if (!_isOnline) {
                            MessageBox.Show("Camera is not online.\r\nPlease check again.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
                        //INIT TESTING
                        b.Content = "Stop Test";
                        b.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#E6D5BD");

                        myGlobal.testinfo.systemlog = "";
                        myGlobal.testinfo.statustest = "Waiting...";
                        _stoptesting = false;
                        chartData.Clear();
                        x = 0;
                        minY = double.MaxValue;
                        maxY = double.MinValue;
                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
                        //GET CAMERA MAC ADDRESS
                        //init camera
                        var camera = new Camera(myGlobal.defaultsetting.cameraip, 23);
                        //login camera
                        if (camera.Login(400) == false) {
                            myGlobal.testinfo.statustest = "FAIL";
                            _btnStart.Content = "Auto Test";
                            _btnStart.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#CC821C");
                            MessageBox.Show("Can't telnet login to camera.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            camera.Close();
                            return;
                        }
                        //get mac address
                        if (camera.getMacAddress() == false) {
                            myGlobal.testinfo.statustest = "FAIL";
                            _btnStart.Content = "Auto Test";
                            _btnStart.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#CC821C");
                            MessageBox.Show("Can't telnet get macaddress of camera.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            camera.Close();
                            return;
                        }
                        //close telnet to camera
                        camera.Close();
                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
                        //CHECK CAMERA IMAGE SHARPNESS
                        Thread t = new Thread(new ThreadStart(() => {
                            int _count = 0;
                        REP:
                            _count++;
                            myGlobal.testinfo.retrytime = string.Format("Test time: {0}", _count.ToString().PadLeft(6));
                            myGlobal.testinfo.testtime = _count.ToString();
                            bool ret = _autoTestSharpness();

                            Dispatcher.Invoke(new Action(() => {
                                AddChartData(double.Parse(myGlobal.testinfo.coefficient));

                                if (double.Parse(myGlobal.testinfo.coefficient) < minY) {
                                    minY = double.Parse(myGlobal.testinfo.coefficient);
                                }
                                if (double.Parse(myGlobal.testinfo.coefficient) > maxY) {
                                    maxY = double.Parse(myGlobal.testinfo.coefficient);
                                }

                                ChartTitle = string.Format("Min value = {0}, Max value = {1}", minY, maxY);
                            }));

                            myGlobal.testinfo.statustest = ret == true ? "PASS" : "FAIL";
                            if (_stoptesting == true || _isOnline == false) {
                                Dispatcher.Invoke(new Action(() => {
                                    _btnStart.Content = "Auto Test";
                                    _btnStart.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#CC821C");
                                }));
                                return;
                            }
                            goto REP;

                        }));
                        t.IsBackground = true;
                        t.Start();
                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
                        //COUNT TIME
                        Thread _zzz = new Thread(new ThreadStart(() => {
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
                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

                        break;
                    }
                case "Stop Test": {
                        b.Content = "Auto Test";
                        b.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#CC821C");
                        _stoptesting = true;
                        break;
                    }
                default: break;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            TabItem selectedTab = e.AddedItems[0] as TabItem;  // Gets selected tab

            switch (selectedTab.Name) {
                case "_tbSys": {
                        myGlobal.maskwindow.Visibility = Visibility.Collapsed;
                        myGlobal.isVisibleMaskWindow = false;
                        break;
                    }
                case "_tbLive": {
                        myGlobal.maskwindow.Visibility = Visibility.Visible;
                        myGlobal.isVisibleMaskWindow = true;
                        break;
                    }
                default: break;
            }

        }
    }
}
