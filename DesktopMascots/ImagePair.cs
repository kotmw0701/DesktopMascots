using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopMascots {
    class ImagePair {
        public MascotImage LeftImage { get; }
        public MascotImage RightImage { get; }

        public ImagePair(MascotImage leftImage, MascotImage rightImage) {
            LeftImage = leftImage;
            RightImage = rightImage;
        }
    }
}
