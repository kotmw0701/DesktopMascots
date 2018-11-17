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

        public double Width { get; set; }
        public double Height { get; set; }

        public Thickness Thickness { get; set; }

        public string Name { get; set; }

        #endregion

        public MascotModel mascotModel;

        /// <summary>
        /// コンストラクタ
        /// HeightとWidthにThicknessを足さないと元画像より若干小さくなる
        /// </summary>
        public MascotViewModel() {
            mascotModel = new MascotModel(new MascotModel.UpdateImage(Update));
            Thickness = new Thickness(5, 10, 5, 10); 
            Chara = mascotModel.Cover.Image;
            Width = mascotModel.Size.Width + Thickness.Right*2;
            Height = mascotModel.Size.Height + Thickness.Top*2;
            Name = mascotModel.Name;
        }
        
        public void Update(ImageBrush image) {
            Chara = image;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyValue) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyValue));
        }
    }
}
