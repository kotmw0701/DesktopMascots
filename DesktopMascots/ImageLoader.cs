using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesktopMascots {
    static class ImageLoader {
        public static ImagePair load(string name, Point center) {
            var onesideBitmap = new Bitmap(name);

            var opposideBitmap = (Bitmap)onesideBitmap.Clone();
            opposideBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

            return new ImagePair(new MascotImage(Convert(onesideBitmap), center), 
                                 new MascotImage(Convert(opposideBitmap), 
                                        new Point(opposideBitmap.Width - center.X, center.Y)));
        }

        private static BitmapImage Convert(Bitmap bitmap) {
            using(var ms = new MemoryStream()) {
                bitmap.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                var bitmapImage = new BitmapImage();

                bitmapImage.BeginInit();//初期化開始

                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.CreateOptions = BitmapCreateOptions.None;

                bitmapImage.StreamSource = ms;

                bitmapImage.EndInit();//初期化終了

                bitmapImage.Freeze();//？

                return bitmapImage;
            }
        }
    }
}
