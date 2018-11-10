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
using System.Windows.Shapes;
using _ocrRealTime.Function;

namespace _ocrRealTime {
    /// <summary>
    /// Interaction logic for MaskWindow.xaml
    /// </summary>
    public partial class MaskWindow : Window {

        
        double posLeft = 0;
        double posTop = 0;
        Boolean isDragging = false;

        public MaskWindow() {
            InitializeComponent();
            this.DataContext = myGlobal.testinfo;

            this._autoShowCropImage();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if (myGlobal.isDrawingRectangle == false) return;

            if (e.ChangedButton == MouseButton.Left) {
                if (isDragging == false) {
                    isDragging = true;
                    posLeft = e.GetPosition(this).X;
                    posTop = e.GetPosition(this).Y;
                }
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e) {
            if (myGlobal.isDrawingRectangle == false) return;

            if (isDragging) {
                double x = e.GetPosition(this).X;
                double y = e.GetPosition(this).Y;

                _rect.Margin = new Thickness(posLeft, posTop, 0, 0);
                _rect.Width = Math.Abs(x - posLeft);
                _rect.Height = Math.Abs(y - posTop);

                //< anzeigen >
                if (_rect.Visibility != Visibility.Visible) { _rect.Visibility = Visibility.Visible; }
                //</ anzeigen >
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e) {
            if (myGlobal.isDrawingRectangle == false) return;

            if (e.ChangedButton == MouseButton.Left) {
                if (isDragging) {
                    isDragging = false;

                    myGlobal.bitmapSnapShot = null;
                    _cropImage.Source = null;

                    _getRectInfo();
                    
                    myGlobal.flags.flagGetRtspFrame = true;
                    _waitSnapShotAndShowCropImage();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (myGlobal.defaultsetting.rectwidth != 0) {
                _rect.Margin = new Thickness(myGlobal.defaultsetting.rectleft, myGlobal.defaultsetting.recttop, 0, 0);
                _rect.Width = myGlobal.defaultsetting.rectwidth;
                _rect.Height = myGlobal.defaultsetting.rectheight;

                //< anzeigen >
                if (_rect.Visibility != Visibility.Visible) { _rect.Visibility = Visibility.Visible; }
                //</ anzeigen >
            }
        }
    }
}
