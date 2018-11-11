using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    class Pose {

        /// <summary>
        /// このフレームの画像
        /// </summary>
        private readonly ImagePair image;

        /// <summary>
        /// X方面への移動量
        /// </summary>
        private readonly int dx;

        /// <summary>
        /// Y方面への移動量
        /// </summary>
        private readonly int dy;

        /// <summary>
        /// 表示時間
        /// </summary>
        private readonly int duration;

        public Pose(ImagePair image) : this(image, 0, 0, 1) { }

        public Pose(ImagePair image, int duration) : this(image, 0, 0, duration) { }

        public Pose(ImagePair image, int dx, int dy, int duration) {

        }
    }
}
