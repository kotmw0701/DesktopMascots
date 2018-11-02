using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopMascots{
    /// <summary>
    /// MascotViewの表示データ諸々更新を管理
    /// (Model) : Mascot.cs
    /// (View) MascotView.xaml.cs
    /// (ViewModel) MascotViewModel.xaml.cs
    /// </summary>
    class MascotViewModel : INotifyPropertyChanged {

        public Mascot mascot = new Mascot();


        //表示中のキャラ画像
        public ImageBrush Chara {
            get { return _chara; }
            set {
                _chara = value;
                onPropertyChanged("Chara");
            }
        }
        private ImageBrush _chara;

        public double Height { get; set; } = 10;
        public double Width { get; set; } = 10;

        public MascotViewModel() {
            Chara = mascot.GetCharaImage(0);
            Height = mascot.Height;
            Width = mascot.Width;
        }

        public void Tick() {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyValue) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyValue));
        }
    }
}
