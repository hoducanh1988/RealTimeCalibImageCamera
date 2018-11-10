using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ocrRealTime.Function {
    public class myGlobal {

        public static TestInformation testinfo = new TestInformation();
        public static MaskWindow maskwindow = new MaskWindow();
        public static FlagManagement flags = new FlagManagement();
        public static DefaultSetting defaultsetting = new DefaultSetting();
        
        public static System.Drawing.Bitmap bitmapSnapShot = null;
        public static System.Drawing.Bitmap bitmapCrop = null;

        public static Boolean isDrawingRectangle = false;

        public static Boolean isCalculateStandardValue = false;

        public static Boolean isVisibleMaskWindow = true;
    }
}
