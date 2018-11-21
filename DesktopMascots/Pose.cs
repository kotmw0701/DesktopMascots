using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    public class Pose {

        /// <summary>
        /// このフレームの画像
        /// </summary>
        public ImagePair ImagePair { get; }

        /// <summary>
        /// X方面への移動量
        /// </summary>
        public int Dx { get; }

        /// <summary>
        /// Y方面への移動量
        /// </summary>
        public int Dy { get; }

        /// <summary>
        /// 表示時間
        /// </summary>
        public int Duration { get; }

        public Pose(ImagePair image) : this(image, 0, 0, 1) { }

        public Pose(ImagePair image, int duration) : this(image, 0, 0, duration) { }

        public Pose(ImagePair image, int dx, int dy, int duration) {
            ImagePair = image;
            Dx = dx;
            Dy = dy;
            Duration = duration;
        }

        public void Next(Mascot mascot) {
            mascot.ImageData = ImagePair.GetImage(mascot.IsLookRight);
        }
    }
}
