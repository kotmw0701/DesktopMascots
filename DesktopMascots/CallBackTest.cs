using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    class CallBackTest {

        public int Value {
            get { return myValue; }
            set {
                myValue = value;
                OnChanged(myValue);
            }
        }
        private int myValue = 0;

        public Action<int> myChanged = null;
        
        private void OnChanged(int value) {
            var onChanged = myChanged;
            if (onChanged == null)
                return;
            onChanged(value);
        }
    }
}
