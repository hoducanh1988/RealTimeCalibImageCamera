using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
using Emgu.CV;
using Emgu.CV.Structure;

namespace _ocrRealTime {
    public partial class MainWindow : Window {

        class LabelInfo {
            public int index { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        List<LabelInfo> _listlabelinfo = null;

        private void lblMin_MouseDown(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e) {
            Label l = sender as Label;
            switch (l.Content) {
                case "X": {
                        this.Close();
                        break;
                    }
                default: {
                        _listlabelinfo = new List<LabelInfo>() {
                            new LabelInfo() { index = 0, name = "LIVE STREAM", width = 110},
                            new LabelInfo() { index = 1, name = "SETTING", width = 110},
                            new LabelInfo() { index = 2, name = "HELP", width = 60},
                            new LabelInfo() { index = 3, name = "ABOUT", width = 100}
                        };

                        int _sum = 0;
                        foreach (var item in _listlabelinfo) {
                            _sum += item.width;
                            if (l.Content.ToString() == item.name) {
                                this.lblMinus.Width = item.width;
                                this.lblMinus.Margin = new Thickness(_sum - item.width, 0, 0, 0);
                                this._BringUCtoFront(item.index);
                                break;
                            }
                        }

                        myGlobal.testinfo.windowopacity = l.Content.ToString() == "LIVE STREAM" ? 1 : 0;

                        break;
                    }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            MenuItem mi = sender as MenuItem;
            switch (mi.Header) {
                case "Exit": {
                        this.Close();
                        break;
                    }
                //case "Drawing Rectangle": {
                //        myGlobal.testinfo.windowopacity = 0.5;
                //        myGlobal.testinfo.windowbackground = Brushes.White;
                //        myGlobal.isDrawingRectangle = true;
                //        break;
                //    }
                //case "Save Rectangle": {
                //        myGlobal.testinfo.windowopacity = 1;
                //        myGlobal.testinfo.windowbackground = Brushes.Transparent;
                //        myGlobal.isDrawingRectangle = false;
                //        break;
                //    }
                case "Rect1": {
                        myGlobal.testinfo.windowopacity = 0.5;
                        myGlobal.testinfo.windowbackground = Brushes.White;
                        myGlobal.isDrawingRectangle1 = true;
                        myGlobal.isDrawingRectangle2 = false;
                        break;
                    }
                case "Rect2": {
                        myGlobal.testinfo.windowopacity = 0.5;
                        myGlobal.testinfo.windowbackground = Brushes.White;
                        myGlobal.isDrawingRectangle1 = false;
                        myGlobal.isDrawingRectangle2 = true;
                        break;
                    }
                case "Save Rect": {
                        myGlobal.testinfo.windowopacity = 1;
                        myGlobal.testinfo.windowbackground = Brushes.Transparent;
                        myGlobal.isDrawingRectangle1 = false;
                        myGlobal.isDrawingRectangle2 = false;
                        break;
                    }

                //case "Save Crop Image": {
                //        Thread t = new Thread(new ThreadStart(() => {
                //            //Snapshot image
                //            myGlobal.bitmapSnapShot = null;
                //            myGlobal.flags.flagGetRtspFrame = true;
                //            while (myGlobal.bitmapSnapShot == null) {
                //                Thread.Sleep(100);
                //            }

                //            //Crop image
                //            Image<Bgr, byte> _image = myBase.CropImageFromBitmap(true);
                //            myGlobal.bitmapCrop = _image.Bitmap;
                //            myGlobal.flags.flagshowcropimage = true;

                //            string _name = myGlobal.defaultsetting.cameraip.Split('.')[3];
                //            myGlobal.bitmapCrop.Save(string.Format("C:\\Users\\ANHHO\\Desktop\\_Camera\\{0}.png", _name));

                //            MessageBox.Show("OK");
                //        }));
                //        t.IsBackground = true;
                //        t.Start();
                        
                //        break;
                //    }
                default: break;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void _SetStartupLocation() {
            double scaleX = 1;
            double scaleY = 1;
            //double scaleX = 0.7;
            //double scaleY = 0.8;
            this.Height = SystemParameters.WorkArea.Height * scaleY;
            this.Width = SystemParameters.WorkArea.Width * scaleX;
            this.Top = (SystemParameters.WorkArea.Height * (1 - scaleY)) / 2;
            this.Left = (SystemParameters.WorkArea.Width * (1 - scaleX)) / 2;
        }

        private void _BringUCtoFront(int index) {
            List<Control> list = new List<Control>() { ucLiveStream, ucSetting, ucHelp, ucAbout };

            for (int i = 0; i < list.Count; i++) {
                if (i == index) {
                    list[i].Visibility = Visibility.Visible;
                    Canvas.SetZIndex(list[i], 1);
                }
                else {
                    list[i].Visibility = Visibility.Collapsed;
                    Canvas.SetZIndex(list[i], 0);
                }
            }
        }
    }
}
