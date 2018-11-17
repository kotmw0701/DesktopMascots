using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// (ViewModel) MascotViewModel.cs
    /// </summary>
    class MascotModel {

        #region 変数,プロパティ

        private Mascot mascot;
        
        public string Name { get { return mascot.Name; } }

        public Size Size { get { return mascot.Size; } }

        public MascotImage Cover { get { return mascot.Cover; } }

        public Manager Manager { get; set; }

        public int Time { get; set; }

        public delegate void UpdateImage(ImageBrush image);

        private UpdateImage updateImage;

        #endregion
        
        public MascotModel(UpdateImage updateImage) {
            mascot = Manager.Instance.GetMascot("Irisu");
        }

        public void Tick() {

        }
    }
}
