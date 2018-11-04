using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesktopMascots {
    /// <summary>
    /// マスコットのメインの処理をする
    /// (Model) : MascotModel.cs
    /// (View) MascotView.xaml.cs
    /// (ViewModel) MascotViewModel.xaml.cs
    /// </summary>
    class MascotModel {

        #region 変数,プロパティ

        //次のページの取得
        public int NextImageNum {
            get {
                if (++_imageNum >= MaxImageNum)
                    _imageNum = 0;
                return _imageNum;
            }
        }
        private int _imageNum = 0;

        //最大ページ数
        public int MaxImageNum { get; set; }

        //マスコットの画像サイズ
        //これは後に別クラスで管理するけど仮置き
        public double Height { get; set; }
        public double Width { get; set; }

        //マスコットの名前
        public string Name { get; set; }

        public Manager Manager { get; set; }

        private ImageBrush[] _charas = new ImageBrush[6];

        public ImageBrush GetNextImage {
            get { return _charas[NextImageNum]; }
        }
        #endregion

        public MascotModel() {
            MaxImageNum = 5;
            for (int i = 0; i < MaxImageNum; i++) {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(@"C:\Sync\gif\irisu\3px\rabiribi_iris_page" + (i + 1) + ".png");
                bitmapImage.EndInit();
                _charas[i] = new ImageBrush { ImageSource = bitmapImage };
            }
            Height = _charas[0].ImageSource.Height;
            Width = _charas[0].ImageSource.Width;
            Name = "Irisu";
        }

        public ImageBrush GetCharaImage(int num) {
            return _charas[num];
        }
    }
}
