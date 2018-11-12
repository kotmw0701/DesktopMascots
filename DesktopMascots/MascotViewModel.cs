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

        public double Width {
            get {
                Console.WriteLine("Get Width: " + _width);
                return _width;
            }
            set {
                Console.WriteLine("Set Width before: " + _width);
                Console.WriteLine("Set Width after:  " + value);
                _width = value;
            }
        }
        public double Height {
            get {
                Console.WriteLine("Get Height: " + _height);
                return _height;
            }
            set {
                Console.WriteLine("Set Height before: " + _height);
                Console.WriteLine("Set Height after:  " + value);
                _height = value;
            }
        }

        private double _width, _height;

        public Thickness Thickness { get; set; }

        public string Name { get; set; }
        
        #endregion

        private MascotModel mascotModel = new MascotModel();

        /// <summary>
        /// コンストラクタ
        /// HeightとWidthにThicknessを足さないと元画像より若干小さくなる
        /// </summary>
        public MascotViewModel() {
            Thickness = new Thickness(5, 10, 5, 10); 
            Chara = mascotModel.Cover.Image;
            double thickWidth = Thickness.Right + Thickness.Left,
                    thickHeight = Thickness.Top + Thickness.Bottom;
            _width = mascotModel.Size.Width + thickWidth;
            _height = mascotModel.Size.Height + thickHeight;
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
