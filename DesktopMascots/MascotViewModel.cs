using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

        public System.Drawing.Size Size { get; set; }

        public Thickness Thickness { get; set; } = new Thickness(5, 10, 5, 10);

        public string Name { get; set; }
        
        #endregion

        private MascotModel mascotModel = new MascotModel();

        /// <summary>
        /// コンストラクタ
        /// HeightとWidthにThicknessを足さないと元画像より若干小さくなる
        /// </summary>
        public MascotViewModel() {
            Chara = mascotModel.Cover.Image;
            //Height = mascotModel.Height + Thickness.Top + Thickness.Bottom;
            //Width = mascotModel.Width + Thickness.Right + Thickness.Left;
            Name = mascotModel.Name;
        }
        
        public void Tick() {
            Chara = mascotModel.Tick();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyValue) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyValue));
        }
    }
}
