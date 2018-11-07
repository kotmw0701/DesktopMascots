using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesktopMascots {
    /// <summary>
    /// 画像データ
    /// </summary>
    class MascotImage {
        public ImageBrush Image { get; }
        /// <summary>
        /// Centerは画像データの真下の真ん中
        /// </summary>
        public Point Center { get; }
        public Size Size { get; }
        
        public MascotImage(BitmapImage image) {
            Image = new ImageBrush { ImageSource = image };
            Size = new Size((int)image.Width, (int)image.Height);
            Center = new Point(Size.Width / 2, Size.Height);
        }

        public MascotImage(BitmapImage image, Point center) {
            Image = new ImageBrush { ImageSource = image };
            Size = new Size((int)image.Width, (int)image.Height);
            Center = center;
        }
    }
}
