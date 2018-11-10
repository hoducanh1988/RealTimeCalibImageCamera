using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ocrRealTime.Function {

    public class DefaultSetting : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void SaveSetting() {
            Properties.Settings.Default.Save();
        }

        public string cameraip {
            get { return Properties.Settings.Default.cameraIP; }
            set {
                Properties.Settings.Default.cameraIP = value;
                rtsppath = string.Format("rtsp://admin:123456@{0}:43794", value);
                OnPropertyChanged(nameof(cameraip));
            }
        }
        public string rtsppath {
            get { return Properties.Settings.Default.rtspPath; }
            set {
                Properties.Settings.Default.rtspPath = value;
                OnPropertyChanged(nameof(rtsppath));
            }
        }
        public string standardvalue {
            get { return Properties.Settings.Default.stdValue; }
            set {
                Properties.Settings.Default.stdValue = value;
                OnPropertyChanged(nameof(standardvalue));
            }
        }
        public string tolerance {
            get { return Properties.Settings.Default.tolerance; }
            set {
                Properties.Settings.Default.tolerance = value;
                OnPropertyChanged(nameof(tolerance));
            }
        }

        public double scalewidth {
            get { return Properties.Settings.Default.scaleWidth; }
            set {
                Properties.Settings.Default.scaleWidth = value;
                OnPropertyChanged(nameof(scalewidth));
            }
        }
        public double scaleheight {
            get { return Properties.Settings.Default.scaleHeight; }
            set {
                Properties.Settings.Default.scaleHeight = value;
                OnPropertyChanged(nameof(scaleheight));
            }
        }

        public double rectwidth {
            get { return Properties.Settings.Default.rectWidth; }
            set {
                Properties.Settings.Default.rectWidth = value;
                OnPropertyChanged(nameof(rectwidth));
            }
        }
        public double rectheight {
            get { return Properties.Settings.Default.rectHeight; }
            set {
                Properties.Settings.Default.rectHeight = value;
                OnPropertyChanged(nameof(rectheight));
            }
        }
        public double recttop {
            get { return Properties.Settings.Default.rectTop; }
            set {
                Properties.Settings.Default.rectTop = value;
                OnPropertyChanged(nameof(recttop));
            }
        }
        public double rectleft {
            get { return Properties.Settings.Default.rectLeft; }
            set {
                Properties.Settings.Default.rectLeft = value;
                OnPropertyChanged(nameof(rectleft));
            }
        }
        public string telnetuser {
            get { return Properties.Settings.Default.telnetuser; }
            set {
                Properties.Settings.Default.telnetuser = value;
                OnPropertyChanged(nameof(telnetuser));
            }
        }
        public string telnetpass {
            get { return Properties.Settings.Default.telnetpass; }
            set {
                Properties.Settings.Default.telnetpass = value;
                OnPropertyChanged(nameof(telnetpass));
            }
        }
    }
}
