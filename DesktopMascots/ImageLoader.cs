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
    /// <summary>
    /// ファイル名から画像を読み込む静的クラス
    /// </summary>
    static class ImageLoader {
        /// <summary>
        /// 画像を読み込んで ImagePair クラスに入れて返す
        /// </summary>
        /// <param name="name">ファイル名</param>
        /// <param name="center">画像の中心点</param>
        /// <returns>ファイル名から生成された画像を格納するImagePair</returns>
        public static ImagePair Load(string name, Point center) {
            var onesideBitmap = new Bitmap(name);

            var opposideBitmap = (Bitmap)onesideBitmap.Clone();
            opposideBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

            return new ImagePair(new MascotImage(Convert(onesideBitmap), center), 
                                 new MascotImage(Convert(opposideBitmap), 
                                        new Point(opposideBitmap.Width - center.X, center.Y)));
        }

        /// <summary>
        /// System.Drawing.Imaging.Bitmap
        /// から
        /// System.Windows.Media.Imaging.BitmapImage
        /// に画像を変換するクラス
        /// </summary>
        /// <param name="bitmap">変換したいBitmapの画像</param>
        /// <returns>BitmapImageに変換後の画像</returns>
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
