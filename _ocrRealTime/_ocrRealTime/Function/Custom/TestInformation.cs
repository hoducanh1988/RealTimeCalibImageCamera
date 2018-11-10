using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _ocrRealTime.Function {
    public class TestInformation : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Constructor
        public TestInformation() {

            myRect = new RectangleInfo();
            myImage = new ImageInfo<int>();
            myImageViewer = new ImageInfo<double>();
            scalewidth = 0;
            scaleheight = 0;

            windowtop = 0;
            windowleft = 0;
            windowwidth = 0;
            windowheight = 0;
            windowbackground = Brushes.Transparent;
            windowopacity = 1;
            statustest = "--";

            elapsedtime = "Elapsed time: 00:00:00    ";
            retrytime = "0";
            systemlog = "";
            rectInfo = "";

            macaddress = "--";
            cropImageSize = "--";
            pixelDeviation = "--";
            coefficient = "--";
            testtime = "--";

            CameraIsOnline = false;
        }

        #region MaskWindowPos

        double _windowtop;
        public double windowtop {
            get { return _windowtop; }
            set {
                _windowtop = value;
                OnPropertyChanged(nameof(windowtop));
            }
        }
        double _windowleft;
        public double windowleft {
            get { return _windowleft; }
            set {
                _windowleft = value;
                OnPropertyChanged(nameof(windowleft));
            }
        }
        double _windowwidth;
        public double windowwidth {
            get { return _windowwidth; }
            set {
                _windowwidth = value;
                OnPropertyChanged(nameof(windowwidth));
            }
        }
        double _windowheight;
        public double windowheight {
            get { return _windowheight; }
            set {
                _windowheight = value;
                OnPropertyChanged(nameof(windowheight));
            }
        }
        SolidColorBrush _windowbackground;
        public SolidColorBrush windowbackground {
            get { return _windowbackground; }
            set {
                _windowbackground = value;
                OnPropertyChanged(nameof(windowbackground));
            }
        }
        double _windowopacity;
        public double windowopacity {
            get { return _windowopacity; }
            set {
                _windowopacity = value;
                OnPropertyChanged(nameof(windowopacity));
            }

        }

        #endregion


        //Property
        public RectangleInfo myRect { get; set; }
        public ImageInfo<int> myImage { get; set; }
        public ImageInfo<double> myImageViewer { get; set; }

        public double scalewidth { get; set; }
        public double scaleheight { get; set; }

        string _statustest;
        public string statustest {
            get { return _statustest; }
            set {
                _statustest = value;
                OnPropertyChanged(nameof(statustest));
            }
        }
        string _elapsedtime;
        public string elapsedtime {
            get { return _elapsedtime; }
            set {
                _elapsedtime = value;
                OnPropertyChanged(nameof(elapsedtime));
            }
        }
        string _retrytime;
        public string retrytime {
            get { return _retrytime; }
            set {
                _retrytime = value;
                OnPropertyChanged(nameof(retrytime));
            }
        }

        string _rectinfo;
        public string rectInfo {
            get { return _rectinfo; }
            set {
                _rectinfo = value;
                OnPropertyChanged(nameof(rectInfo));
            }
        }
        string _crImageSize;
        public string cropImageSize {
            get { return _crImageSize; }
            set {
                _crImageSize = value;
                OnPropertyChanged(nameof(cropImageSize));
            }
        }
        string _pxDeviation;
        public string pixelDeviation {
            get { return _pxDeviation; }
            set {
                _pxDeviation = value;
                OnPropertyChanged(nameof(pixelDeviation));
            }
        }
        string _coefficient;
        public string coefficient {
            get { return _coefficient; }
            set {
                _coefficient = value;
                OnPropertyChanged(nameof(coefficient));
            }
        }
        string _testtime;
        public string testtime {
            get { return _testtime; }
            set {
                _testtime = value;
                OnPropertyChanged(nameof(testtime));
            }
        }

        string _systemlog;
        public string systemlog {
            get { return _systemlog; }
            set {
                _systemlog = value;
                OnPropertyChanged(nameof(systemlog));
            }
        }
        public string rtsppath {
            get { return Properties.Settings.Default.rtspPath; }
            set {
                Properties.Settings.Default.rtspPath = value;
                OnPropertyChanged(nameof(rtsppath));
            }
        }
        bool _cameraisonline;
        public bool CameraIsOnline {
            get { return _cameraisonline; }
            set {
                _cameraisonline = value;
                OnPropertyChanged(nameof(CameraIsOnline));
            }
        }
        string _mac;
        public string macaddress {
            get { return _mac; }
            set {
                _mac = value;
                OnPropertyChanged(nameof(macaddress));
            }
        }


    }

    /// <summary>
    /// 
    /// </summary>
    public class RectangleInfo {
        public double rectTop { get; set; }
        public double rectLeft { get; set; }
        public double rectWidth { get; set; }
        public double rectHeight { get; set; }

        public override string ToString() {
            return string.Format("Top={0}, Left={1}, Width={2}, Height={3}", rectTop, rectLeft, rectWidth, rectHeight);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImageInfo<T> {
        public T width { get; set; }
        public T height { get; set; }

        public override string ToString() {
            return string.Format("Width={0}, Height={1}", width, height);
        }
    }

}
