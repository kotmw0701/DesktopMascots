using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DesktopMascots {
    class MascotViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        private ImageBrush _chara;
        public ImageBrush Chara {
            get => _chara;
            set {
                if (value == _chara)
                    return;
                _chara = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Chara));
            }
        }

        public string Name { get; }

        public System.Drawing.Size Size { get; set; }

        public Thickness Thickness { get; }

        public MascotViewModel() {
            Thickness = new Thickness(5, 10, 5, 10);
        }
    }
}
