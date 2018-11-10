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

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace _ocrRealTime.ucControl {
    /// <summary>
    /// Interaction logic for ucLiveStream.xaml
    /// </summary>
    public partial class ucLiveStream : UserControl {
    
        private bool _autoTestSharpness() {
            try {
                //myGlobal.testinfo.statustest = "Waiting...";
                //Snapshot image
                myGlobal.bitmapSnapShot = null;
                myGlobal.flags.flagGetRtspFrame = true;
                while (myGlobal.bitmapSnapShot == null) {
                    Thread.Sleep(100);
                }

                //Crop image
                Image<Gray, byte> _image = myBase.CropImageFromBitmap();
                myGlobal.bitmapCrop = _image.Bitmap;


                myGlobal.flags.flagshowcropimage = true;
                string _name = myGlobal.defaultsetting.cameraip.Split('.')[3];

                //Far = 2.0 m
                int s = _getSharpnessValue(_image);
                int pixel = _image.Width * _image.Height;
                double scale = s / (pixel * 1.0);

                myGlobal.testinfo.pixelDeviation = string.Format("{0}", s);
                myGlobal.testinfo.cropImageSize = string.Format("width={0}, height={1}, pixel={2}", _image.Width, _image.Height, pixel);
                myGlobal.testinfo.coefficient = string.Format("{0}", Math.Round(scale, 2));

                //myGlobal.testinfo.rectInfo = string.Format("sum={0}, pixel={1}, scale={2}", s, pixel, scale);
                //var st = new System.IO.StreamWriter(@"C:\Users\ANHHO\Desktop\_LOG\" + _name + "_F.csv", true);
                //st.WriteLine(scale.ToString());
                //st.Dispose();

                //return true;
                return (scale >= (double.Parse(myGlobal.defaultsetting.standardvalue) - double.Parse(myGlobal.defaultsetting.tolerance)));
            } catch {
                return false;
            }
        }

        private byte _px(Image<Gray, byte> img, int x, int y) {
            return img.Data[y,x,0];
        }

        private int _getSharpnessValue(Image<Gray, byte> image) {
            int height = image.Height;
            int width = image.Width;

            int sum = 0;
            for (int x = 0; x < width - 1; x++) {
                for (int y = 0; y < height; y++) {
                    sum += Math.Abs(_px(image, x, y) - _px(image, x + 1, y));
                }
            }

            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cropImage"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        string _getTextFromCropImage(Image<Gray, byte> cropImage) {
            if (cropImage == null) return null;

            try {
                Tesseract OCRz = new Tesseract("./tessdata", "calibri", OcrEngineMode.Default);
                //Tesseract OCRz = new Tesseract("./tessdata", "roman", OcrEngineMode.Default);
                OCRz.SetImage(cropImage);
                OCRz.PageSegMode = PageSegMode.Auto;

                OCRz.Recognize();
                string _text = OCRz.GetUTF8Text();
                return _text;
            }
            catch {
                return null;
            }
        }

    }
}
