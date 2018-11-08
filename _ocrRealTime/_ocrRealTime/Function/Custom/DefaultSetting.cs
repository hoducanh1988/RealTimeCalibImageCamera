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
        public string standardcharacters {
            get { return Properties.Settings.Default.stdChars; }
            set {
                Properties.Settings.Default.stdChars = value;
                OnPropertyChanged(nameof(standardcharacters));
            }
        }
        public double standardvalue {
            get { return Properties.Settings.Default.stdValue; }
            set {
                Properties.Settings.Default.stdValue = value;
                OnPropertyChanged(nameof(standardvalue));
            }
        }
        public string comparetype {
            get { return Properties.Settings.Default.cmpType; }
            set {
                Properties.Settings.Default.cmpType = value;
                OnPropertyChanged(nameof(comparetype));
            }
        }

        public double rect1width {
            get { return Properties.Settings.Default.rect1Width; }
            set {
                Properties.Settings.Default.rect1Width = value;
                OnPropertyChanged(nameof(rect1width));
            }
        }
        public double rect1height {
            get { return Properties.Settings.Default.rect1Height; }
            set {
                Properties.Settings.Default.rect1Height = value;
                OnPropertyChanged(nameof(rect1height));
            }
        }
        public double rect1top {
            get { return Properties.Settings.Default.rect1Top; }
            set {
                Properties.Settings.Default.rect1Top = value;
                OnPropertyChanged(nameof(rect1top));
            }
        }
        public double rect1left {
            get { return Properties.Settings.Default.rect1Left; }
            set {
                Properties.Settings.Default.rect1Left = value;
                OnPropertyChanged(nameof(rect1left));
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

        public double rect2width {
            get { return Properties.Settings.Default.rect2Width; }
            set {
                Properties.Settings.Default.rect2Width = value;
                OnPropertyChanged(nameof(rect2width));
            }
        }
        public double rect2height {
            get { return Properties.Settings.Default.rect2Height; }
            set {
                Properties.Settings.Default.rect2Height = value;
                OnPropertyChanged(nameof(rect2height));
            }
        }
        public double rect2top {
            get { return Properties.Settings.Default.rect2Top; }
            set {
                Properties.Settings.Default.rect2Top = value;
                OnPropertyChanged(nameof(rect2top));
            }
        }
        public double rect2left {
            get { return Properties.Settings.Default.rect2Left; }
            set {
                Properties.Settings.Default.rect2Left = value;
                OnPropertyChanged(nameof(rect2left));
            }
        }
    }
}
