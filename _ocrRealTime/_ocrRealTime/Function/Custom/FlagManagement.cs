using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ocrRealTime.Function {

    public class FlagManagement : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Constructor
        public FlagManagement() {
            flagGetRtspFrame = false;
            flagshowcropimage = false;
        }

        //Property
        bool _flaggetrtspframe;
        public bool flagGetRtspFrame {
            get { return _flaggetrtspframe; }
            set {
                _flaggetrtspframe = value;
                OnPropertyChanged(nameof(flagGetRtspFrame));
            }
        }
        bool _flagshowcropimage;
        public bool flagshowcropimage {
            get { return _flagshowcropimage; }
            set {
                _flagshowcropimage = value;
                OnPropertyChanged(nameof(flagshowcropimage));
            }
        }



    }
}
