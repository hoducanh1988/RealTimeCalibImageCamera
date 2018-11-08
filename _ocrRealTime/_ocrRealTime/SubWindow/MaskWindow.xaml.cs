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
            if (myGlobal.isDrawingRectangle1 == false && myGlobal.isDrawingRectangle2 == false) return;

            if (e.ChangedButton == MouseButton.Left) {
                if (isDragging == false) {
                    isDragging = true;
                    posLeft = e.GetPosition(this).X;
                    posTop = e.GetPosition(this).Y;
                }
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e) {
            if (myGlobal.isDrawingRectangle1 == false && myGlobal.isDrawingRectangle2 == false) return;

            if (isDragging) {
                double x = e.GetPosition(this).X;
                double y = e.GetPosition(this).Y;

                if (myGlobal.isDrawingRectangle1 == true) {
                    _rect1.Margin = new Thickness(posLeft, posTop, 0, 0);
                    _rect1.Width = Math.Abs(x - posLeft);
                    _rect1.Height = Math.Abs(y - posTop);

                    //< anzeigen >
                    if (_rect1.Visibility != Visibility.Visible) { _rect1.Visibility = Visibility.Visible; }
                    //</ anzeigen >
                    return;
                }
                if (myGlobal.isDrawingRectangle2 == true) {
                    _rect2.Margin = new Thickness(posLeft, posTop, 0, 0);
                    _rect2.Width = Math.Abs(x - posLeft);
                    _rect2.Height = Math.Abs(y - posTop);

                    //< anzeigen >
                    if (_rect2.Visibility != Visibility.Visible) { _rect2.Visibility = Visibility.Visible; }
                    //</ anzeigen >
                    return;
                }

            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e) {
            if (myGlobal.isDrawingRectangle1 == false && myGlobal.isDrawingRectangle2 == false) return;

            if (e.ChangedButton == MouseButton.Left) {
                if (isDragging) {
                    isDragging = false;

                    myGlobal.bitmapSnapShot = null;
                    _cropImage1.Source = null;
                    _cropImage2.Source = null;

                    _getRectInfo();
                    
                    myGlobal.flags.flagGetRtspFrame = true;
                    _waitSnapShotAndShowCropImage();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (myGlobal.defaultsetting.rect1width != 0 && myGlobal.defaultsetting.rect1height != 0) {
                _rect1.Margin = new Thickness(myGlobal.defaultsetting.rect1left, myGlobal.defaultsetting.rect1top, 0, 0);
                _rect1.Width = myGlobal.defaultsetting.rect1width;
                _rect1.Height = myGlobal.defaultsetting.rect1height;

                //< anzeigen >
                if (_rect1.Visibility != Visibility.Visible) { _rect1.Visibility = Visibility.Visible; }
                //</ anzeigen >
            }
            if (myGlobal.defaultsetting.rect2width != 0 && myGlobal.defaultsetting.rect2height != 0) {
                _rect2.Margin = new Thickness(myGlobal.defaultsetting.rect2left, myGlobal.defaultsetting.rect2top, 0, 0);
                _rect2.Width = myGlobal.defaultsetting.rect2width;
                _rect2.Height = myGlobal.defaultsetting.rect2height;

                //< anzeigen >
                if (_rect2.Visibility != Visibility.Visible) { _rect2.Visibility = Visibility.Visible; }
                //</ anzeigen >
            }
        }
    }
}
