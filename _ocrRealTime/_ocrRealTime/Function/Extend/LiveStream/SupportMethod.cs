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
                Image<Gray, byte> _image1 = myBase.CropImageFromBitmap(1);
                myGlobal.bitmapCrop1 = _image1.Bitmap;

                Image<Gray, byte> _image2 = myBase.CropImageFromBitmap(2);
                myGlobal.bitmapCrop2 = _image2.Bitmap;

                myGlobal.flags.flagshowcropimage = true;

                //Translate image to text
                //string _text = _getTextFromCropImage(_image);
                //myGlobal.testinfo.systemlog += string.Format(">>> {0}, TEXT = {1}\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ffff"), _text.Replace("\r","").Replace("\n","").Trim());

                //Compare text with standard
                //bool ret = myGlobal.defaultsetting.comparetype == "Case Sensitivity" ? _text.Contains(myGlobal.defaultsetting.standardcharacters) : _text.ToLower().Contains(myGlobal.defaultsetting.standardcharacters.ToLower());

                //myGlobal.testinfo.statustest = ret == true ? "PASS" : "FAIL";
                //return ret;

                //Near = 0.3 m
                //int s = _getSharpnessValue(_image1);
                //int pixel = _image1.Width * _image1.Height;
                //double scale = s / (pixel * 1.0);
                string _name = myGlobal.defaultsetting.cameraip.Split('.')[3];
                //myGlobal.testinfo.rect1Info = string.Format("Rect1, sum={0}, pixel={1}, scale={2}", s, pixel, scale);
                //System.IO.StreamWriter st = new System.IO.StreamWriter(@"C:\Users\ANHHO\Desktop\_LOG\" + _name + "_N.csv", true);
                //st.WriteLine(scale.ToString());
                //st.Dispose();

                //Far = 2.0 m
                int s = _getSharpnessValue(_image2);
                int pixel = _image2.Width * _image2.Height;
                double scale = s / (pixel * 1.0);
                myGlobal.testinfo.rect2Info = string.Format("Rect2, sum={0}, pixel={1}, scale={2}", s, pixel, scale);
                var st = new System.IO.StreamWriter(@"C:\Users\ANHHO\Desktop\_LOG\" + _name + "_F.csv", true);
                st.WriteLine(scale.ToString());
                st.Dispose();

                //return true;
                return (scale >= myGlobal.defaultsetting.standardvalue);
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
