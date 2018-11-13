using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    /// <summary>
    /// コンフィグを管理するクラス
    /// Jsonで保存してるよ
    /// </summary>
    class Configuration {

        public class Rootobject {
            public string Name { get; set; }
            public Action[] Actions { get; set; }
        }

        public class Action {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Duration { get; set; }
            public Animation[] Animation { get; set; }
        }

        public class Animation {
            public string Image { get; set; }
        }

    }
}
