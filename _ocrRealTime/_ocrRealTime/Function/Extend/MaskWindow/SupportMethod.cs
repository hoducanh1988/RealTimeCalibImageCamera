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
                if (myGlobal.isDrawingRectangle1 == true) {
                    myGlobal.testinfo.myRect1.rectTop = _rect1.Margin.Top;
                    myGlobal.testinfo.myRect1.rectLeft = _rect1.Margin.Left;
                    myGlobal.testinfo.myRect1.rectWidth = _rect1.Width;
                    myGlobal.testinfo.myRect1.rectHeight = _rect1.Height;

                    myGlobal.defaultsetting.rect1top = myGlobal.testinfo.myRect1.rectTop;
                    myGlobal.defaultsetting.rect1left = myGlobal.testinfo.myRect1.rectLeft;
                    myGlobal.defaultsetting.rect1width = myGlobal.testinfo.myRect1.rectWidth;
                    myGlobal.defaultsetting.rect1height = myGlobal.testinfo.myRect1.rectHeight;
                }

                if (myGlobal.isDrawingRectangle2 == true) {
                    myGlobal.testinfo.myRect2.rectTop = _rect2.Margin.Top;
                    myGlobal.testinfo.myRect2.rectLeft = _rect2.Margin.Left;
                    myGlobal.testinfo.myRect2.rectWidth = _rect2.Width;
                    myGlobal.testinfo.myRect2.rectHeight = _rect2.Height;

                    myGlobal.defaultsetting.rect2top = myGlobal.testinfo.myRect2.rectTop;
                    myGlobal.defaultsetting.rect2left = myGlobal.testinfo.myRect2.rectLeft;
                    myGlobal.defaultsetting.rect2width = myGlobal.testinfo.myRect2.rectWidth;
                    myGlobal.defaultsetting.rect2height = myGlobal.testinfo.myRect2.rectHeight;
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
                if (myGlobal.isDrawingRectangle1 == true) {
                    myGlobal.testinfo.myImage1.width = myGlobal.bitmapSnapShot.Width;
                    myGlobal.testinfo.myImage1.height = myGlobal.bitmapSnapShot.Height;
                }
                if (myGlobal.isDrawingRectangle2 == true) {
                    myGlobal.testinfo.myImage2.width = myGlobal.bitmapSnapShot.Width;
                    myGlobal.testinfo.myImage2.height = myGlobal.bitmapSnapShot.Height;
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
                if (myGlobal.isDrawingRectangle1 == true) {
                    myGlobal.testinfo.scalewidth = Math.Round(myGlobal.testinfo.myImage1.width / myGlobal.testinfo.myImageViewer.width, 2);
                    myGlobal.testinfo.scaleheight = Math.Round(myGlobal.testinfo.myImage1.height / myGlobal.testinfo.myImageViewer.height, 2);
                }
                if (myGlobal.isDrawingRectangle2 == true) {
                    myGlobal.testinfo.scalewidth = Math.Round(myGlobal.testinfo.myImage2.width / myGlobal.testinfo.myImageViewer.width, 2);
                    myGlobal.testinfo.scaleheight = Math.Round(myGlobal.testinfo.myImage2.height / myGlobal.testinfo.myImageViewer.height, 2);
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

                        Image<Gray, byte> _img1 = myBase.CropImageFromBitmap(1);
                        if (_img1 != null) {
                            _cropImage1.Source = myBase.Bitmap2BitmapImage(_img1.Bitmap);
                        }

                        Image<Gray, byte> _img2 = myBase.CropImageFromBitmap(2);
                        if (_img2 != null) {
                            _cropImage2.Source = myBase.Bitmap2BitmapImage(_img2.Bitmap);
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
                                if (myGlobal.bitmapCrop1 != null) {
                                    _cropImage1.Source = myBase.Bitmap2BitmapImage(myGlobal.bitmapCrop1);
                                    myGlobal.flags.flagshowcropimage = false;
                                }
                                if (myGlobal.bitmapCrop2 != null) {
                                    _cropImage2.Source = myBase.Bitmap2BitmapImage(myGlobal.bitmapCrop2);
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
