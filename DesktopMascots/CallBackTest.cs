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
                OnChanged("Value Set", myValue);
            }
        }
        private int myValue = 0;

        public int Value2 {
            get {
                return myValue2;
            }
            set {
                myValue2 = value;
                OnChanged("Value2 Set", myValue2);
            }
        }
        private int myValue2 = 0;

        public Action<string, int> myChanged = null;
        
        private void OnChanged(string str, int value) {
            var onChanged = myChanged;
            if (onChanged == null)
                return;
            onChanged(str, value);
        }
    }
}
