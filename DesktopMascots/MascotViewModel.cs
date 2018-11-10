using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DesktopMascots{
    /// <summary>
    /// MascotViewの表示データ諸々更新を管理
    /// (Model) : Mascot.cs
    /// (View) MascotView.xaml.cs
    /// (ViewModel) MascotViewModel.xaml.cs
    /// </summary>
    class MascotViewModel : INotifyPropertyChanged {

        #region Bindingデータ

        //表示中のキャラ画像
        public ImageBrush Chara {
            get { return _chara; }
            set {
                _chara = value;
                onPropertyChanged("Chara");
            }
        }
        private ImageBrush _chara;

        public double Height { get; set; } = 20;
        public double Width { get; set; } = 20;

        public Thickness Thickness { get; set; }

        public string Name { get; set; }
        
        #endregion

        private MascotModel mascot = new MascotModel();

        /// <summary>
        /// コンストラクタ
        /// HeightとWidthにThicknessを足さないと元画像より若干小さくなる
        /// </summary>
        public MascotViewModel() {
            Thickness = new Thickness {
                Bottom = 5,
                Left = 10,
                Right = 10,
                Top = 5
            };
            Chara = mascot.Cover;
            Height = mascot.Height + Thickness.Top + Thickness.Bottom;
            Width = mascot.Width + Thickness.Right + Thickness.Left;
            Name = mascot.Name;
        }
        
        public void Tick() {
            Chara = mascot.Tick();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyValue) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyValue));
        }
    }
}
