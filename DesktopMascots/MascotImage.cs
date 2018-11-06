using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesktopMascots {
    class MascotImage {
        public ImageBrush Image { get; }
        public Point Center { get; }
        public double Height { get; }
        public double Width { get; }

        public MascotImage(BitmapImage image, Point center) {
            Image = new ImageBrush { ImageSource = image };
            Center = center;
            Height = image.Height;
            Width = image.Width;
        }
    }
}
