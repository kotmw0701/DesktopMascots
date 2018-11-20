using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopMascots {
    public class Mascot {

        public delegate void UpdateImage(ImageBrush image);
        public UpdateImage updateAction = null;

        private MascotImage _mascotImage;
        public MascotImage ImageData {
            get => _mascotImage;
            set {
                if (_mascotImage == value)
                    return;
                _mascotImage = value;
                if (updateAction == null)
                    return;
                updateAction(value.Image);
            }
        }

        public string Name { get; }
        public Size Size { get; }
        public int Time { get; private set; }
        public bool IsLookRight { get; } = false;
        //一時的
        public Animation animation;

        public Mascot(Animation animation, string name = "chara") {
            Name = name;
            this.animation = animation;
            animation.Next(0, this);
            Size = ImageData.Size;
        }

        public void Tick() {
            animation.Next(Time, this);
            Time++;
        }
    }
}
