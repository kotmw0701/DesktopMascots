using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    class ActionBase : IAction {
        public bool HasNext() {
            return false;
        }

        public void Init() {

        }

        public void Next() {

        }
    }
}
