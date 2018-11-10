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

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace _ocrRealTime {
    /// <summary>
    /// Interaction logic for MaskWindow.xaml
    /// </summary>
    public partial class MaskWindow : Window {

        Object _lock = new Object();
        Thread _threadShowCropImage = null;

        private bool _getRectInfo() {
            try {
                if (myGlobal.isDrawingRectangle == true) {
                    myGlobal.testinfo.myRect.rectTop = _rect.Margin.Top;
                    myGlobal.testinfo.myRect.rectLeft = _rect.Margin.Left;
                    myGlobal.testinfo.myRect.rectWidth = _rect.Width;
                    myGlobal.testinfo.myRect.rectHeight = _rect.Height;

                    myGlobal.defaultsetting.recttop = myGlobal.testinfo.myRect.rectTop;
                    myGlobal.defaultsetting.rectleft = myGlobal.testinfo.myRect.rectLeft;
                    myGlobal.defaultsetting.rectwidth = myGlobal.testinfo.myRect.rectWidth;
                    myGlobal.defaultsetting.rectheight = myGlobal.testinfo.myRect.rectHeight;
                }

                myGlobal.defaultsetting.SaveSetting();
                return true;
            }
            catch {
                return false;
            }
        }

        private bool _getSnapShotImageSize() {
            if (myGlobal.bitmapSnapShot == null) return false;
            try {
                if (myGlobal.isDrawingRectangle == true) {
                    myGlobal.testinfo.myImage.width = myGlobal.bitmapSnapShot.Width;
                    myGlobal.testinfo.myImage.height = myGlobal.bitmapSnapShot.Height;
                }
                return true;
            } catch {
                return false;
            }
        }

        private bool _getImageViewerSize() {
            try {
                myGlobal.testinfo.myImageViewer.width = this.Width;
                myGlobal.testinfo.myImageViewer.height = this.Height;
                return true;
            } catch {
                return false;
            }
        }

        private bool _calculateScaleImagevsImageViewer() {
            try {
                if (myGlobal.isDrawingRectangle == true) {
                    myGlobal.testinfo.scalewidth = Math.Round(myGlobal.testinfo.myImage.width / myGlobal.testinfo.myImageViewer.width, 2);
                    myGlobal.testinfo.scaleheight = Math.Round(myGlobal.testinfo.myImage.height / myGlobal.testinfo.myImageViewer.height, 2);
                }
                
                myGlobal.defaultsetting.scalewidth = myGlobal.testinfo.scalewidth;
                myGlobal.defaultsetting.scaleheight = myGlobal.testinfo.scaleheight;
                myGlobal.defaultsetting.SaveSetting();
                return true;
            } catch {
                return false;
            }
        }

       
        private void _waitSnapShotAndShowCropImage() {
            Thread t = new Thread(new ThreadStart(() =>
            {
                _threadShowCropImage.Abort();
                lock (_lock) {
                    int _count = 0;
                    while (myGlobal.bitmapSnapShot == null) {
                        _count++;
                        Thread.Sleep(100);
                        if (_count >= 50) break;
                    }

                    if (_count >= 50) return;

                    App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        _getSnapShotImageSize();
                        _getImageViewerSize();
                        _calculateScaleImagevsImageViewer();

                        Image<Gray, byte> _img = myBase.CropImageFromBitmap();
                        if (_img != null) {
                            _cropImage.Source = myBase.Bitmap2BitmapImage(_img.Bitmap);
                        }

                    }));

                    _autoShowCropImage();
                }
            }));
            t.IsBackground = true;
            t.Start();
        }


        private void _autoShowCropImage() {
            _threadShowCropImage = new Thread(new ThreadStart(() =>
            {
                lock (_lock) {
                    while (true) {
                        if (myGlobal.flags.flagshowcropimage == true) {
                            App.Current.Dispatcher.Invoke(new Action(() =>
                            {
                                if (myGlobal.bitmapCrop != null) {
                                    _cropImage.Source = myBase.Bitmap2BitmapImage(myGlobal.bitmapCrop);
                                    myGlobal.flags.flagshowcropimage = false;
                                }
                            }));
                        }
                        Thread.Sleep(250);
                    }
                }
            }));
            _threadShowCropImage.IsBackground = true;
            _threadShowCropImage.Start();
        }

    }
}
