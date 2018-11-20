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
using static DesktopMascots.Mascot;

namespace DesktopMascots {
    class MascotViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// メインの画像データ
        /// </summary>
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

        /// <summary>
        /// 今のキャラの名前
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 画像サイズ
        /// </summary>
        public System.Drawing.Size Size { get; set; }

        /// <summary>
        /// 影を表示させるために用意する幅
        /// </summary>
        public Thickness Thickness { get; } = new Thickness(5, 10, 5, 10);

        /// <summary>
        /// MascotViewにMascotのデータを投げる
        /// </summary>
        public void Init(Mascot mascot) {
            mascot.updateAction = Update;
            Chara = mascot.ImageData.Image;
            Name = mascot.Name;
            Size = mascot.Size + new System.Drawing.Size((int)Thickness.Left * 2, (int)Thickness.Top * 2);
        }

        /// <summary>
        /// 外部から画像をUI Threadに同期的に更新させる為のメソッド
        /// </summary>
        /// <param name="image">更新する画像</param>
        public void Update(ImageBrush image) {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                Chara = image;
            }));
        }

        public override string ToString() {
            return $"[Name : {Name}, Size : {Size}, Image : {Chara}]";
        }
    }
}
