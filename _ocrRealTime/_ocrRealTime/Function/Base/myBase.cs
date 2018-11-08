using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _ocrRealTime.Function {
    public class myBase {

        public static BitmapImage ReadBitmapImageFromFile(string _file) {
            //FileStream fileStream = new FileStream(_file, FileMode.Open, FileAccess.Read);
            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(_file);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bitmap.EndInit();
            bitmap.Freeze(); //This is the magic line that releases/unlocks the file.

            return bitmap;
        }

        public static System.Drawing.Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage) {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream()) {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new System.Drawing.Bitmap(bitmap);
            }
        }

        public static BitmapImage Bitmap2BitmapImage(System.Drawing.Bitmap bitmap) {
            using (var memory = new MemoryStream()) {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageIn"></param>
        /// <param name="imageOut"></param>
        /// <returns></returns>
        public static bool ConvertImageFromBgrToGray(Image<Bgr, byte> imageIn, ref Image<Gray, byte> imageOut) {
            if (imageIn == null) return false;

            try {
                /*Change color space from BGR to Gray ---------------*/
                Image<Gray, byte> imgGray = new Image<Gray, byte>(imageIn.Width, imageIn.Height, new Gray(0));
                CvInvoke.CvtColor(imageIn, imgGray, ColorConversion.Rgb2Gray);

                /*Apply Morphological Gradient ---------------------*/
                //Image<Gray, byte> img_threshold = new Image<Gray, byte>(imageIn.Width, imageIn.Height);
                //Mat morphStructure1 = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new System.Drawing.Size(3, 3), new System.Drawing.Point());
                //CvInvoke.MorphologyEx(imgGray, img_threshold, MorphOp.Gradient, morphStructure1, new System.Drawing.Point(), 1, BorderType.Default, new MCvScalar());
                //imageOut = img_threshold;

                /*Apply threshold to convert to binary image -------*/
                Image<Gray, byte> img_binary = new Image<Gray, byte>(imageIn.Width, imageIn.Height);
                //CvInvoke.Threshold(img_threshold, img_binary, 0, 255, ThresholdType.Binary | ThresholdType.Otsu); -06.11
                CvInvoke.Threshold(imgGray, img_binary, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);

                imageOut = img_binary;
                //imageOut = imgGray;
                return true;
            }
            catch {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static  RectangleInfo ConvertRect(int _index) {
            RectangleInfo _rect = new RectangleInfo();
            _rect.rectWidth = _index == 1 ?  myGlobal.defaultsetting.rect1width * myGlobal.defaultsetting.scalewidth : myGlobal.defaultsetting.rect2width * myGlobal.defaultsetting.scalewidth;
            _rect.rectLeft = _index == 1 ? myGlobal.defaultsetting.rect1left * myGlobal.defaultsetting.scalewidth : myGlobal.defaultsetting.rect2left * myGlobal.defaultsetting.scalewidth;
            _rect.rectHeight = _index == 1? myGlobal.defaultsetting.rect1height * myGlobal.defaultsetting.scaleheight : myGlobal.defaultsetting.rect2height * myGlobal.defaultsetting.scaleheight;
            _rect.rectTop = _index == 1? myGlobal.defaultsetting.rect1top * myGlobal.defaultsetting.scaleheight : myGlobal.defaultsetting.rect2top * myGlobal.defaultsetting.scaleheight;
            
            return _rect;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Image<Gray, byte> CropImageFromBitmap(int _index) {
            if (myGlobal.bitmapSnapShot == null) return null;

            try {
                Image<Bgr, byte> _imageRef = null;
                RectangleInfo _rectInfo = ConvertRect(_index);

                Image<Bgr, byte> imageInput = new Image<Bgr, byte>(myGlobal.bitmapSnapShot);
                System.Drawing.Rectangle _rect = new System.Drawing.Rectangle((int)_rectInfo.rectLeft, (int)_rectInfo.rectTop, (int)_rectInfo.rectWidth, (int)_rectInfo.rectHeight);
                imageInput.ROI = _rect;
                _imageRef = imageInput.CopyBlank();
                imageInput.CopyTo(_imageRef);
                imageInput.ROI = System.Drawing.Rectangle.Empty;

                Image<Gray, byte> _imgGray = new Image<Gray, byte>(_imageRef.Width, _imageRef.Height);
                myBase.ConvertImageFromBgrToGray(_imageRef, ref _imgGray);

                return _imgGray;
            }
            catch {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Image<Bgr, byte> CropImageFromBitmap(int _index, bool _flag) {
            if (myGlobal.bitmapSnapShot == null) return null;

            try {
                Image<Bgr, byte> _imageRef = null;
                RectangleInfo _rectInfo = ConvertRect(_index);

                Image<Bgr, byte> imageInput = new Image<Bgr, byte>(myGlobal.bitmapSnapShot);
                System.Drawing.Rectangle _rect = new System.Drawing.Rectangle((int)_rectInfo.rectLeft, (int)_rectInfo.rectTop, (int)_rectInfo.rectWidth, (int)_rectInfo.rectHeight);
                imageInput.ROI = _rect;
                _imageRef = imageInput.CopyBlank();
                imageInput.CopyTo(_imageRef);
                imageInput.ROI = System.Drawing.Rectangle.Empty;

                //Image<Gray, byte> _imgGray = new Image<Gray, byte>(_imageRef.Width, _imageRef.Height);
                //myBase.ConvertImageFromBgrToGray(_imageRef, ref _imgGray);
                //return _imgGray;

                return _imageRef;
            }
            catch {
                return null;
            }
        }

    }
}
