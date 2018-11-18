using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    class Animation {
        public Pose[] Poses { get; }

        public Animation(Pose[] poses) {
            if (poses.Length == 0)
                throw new ArgumentNullException("posesに何も入ってないです");
            Poses = poses;
        }

        public void next(int time/*もう一つ引数*/) {

        }

        public Pose GetPoseAtTime(int time) {
            int mod = time % GetDuration();
            foreach (Pose pose in Poses) {
                mod -= pose.Duration;
                if (mod < 0)
                    return pose;
            }
            return null;
        }

        public int GetDuration() {
            int duration = 0;
            Poses.Select(pose => duration += pose.Duration);
            return duration;
        }
    }
}
