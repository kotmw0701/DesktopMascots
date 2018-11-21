using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopMascots {
    /// <summary>
    /// 両方向きの画像を管理
    /// </summary>
    public class ImagePair {
        private MascotImage LeftImage { get; }
        private MascotImage RightImage { get; }

        public ImagePair(MascotImage leftImage, MascotImage rightImage) {
            LeftImage = leftImage;
            RightImage = rightImage;
        }

        public MascotImage GetImage(bool lookRight) {
            return lookRight ? RightImage : LeftImage;
        }
    }
}
