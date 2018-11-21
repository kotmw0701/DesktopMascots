using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    public class Animation {
        public Pose[] Poses { get; }
        private readonly int duration;

        public Animation(Pose[] poses) {
            if (poses.Length == 0)
                throw new ArgumentNullException("posesに何も入ってないです");
            Poses = poses;
            duration = GetDuration();
        }

        public void Next(int time, Mascot mascot) {
            GetPoseAtTime(time).Next(mascot);
        }

        public Pose GetPoseAtTime(int time) {
            int mod = time % duration;
            foreach (Pose pose in Poses) {
                mod -= pose.Duration;
                if (mod < 0)
                    return pose;
            }
            return null;
        }

        public int GetDuration() {
            int duration = 0;
            foreach (Pose pose in Poses) duration += pose.Duration;
            return duration;
        }
    }
}
