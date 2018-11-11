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
    /// (ViewModel) MascotViewModel.xaml.cs
    /// </summary>
    class MascotModel {

        #region 変数,プロパティ

        private Mascot mascot;
        
        public string Name { get { return mascot.Name; } }

        public Size Size { get { return mascot.Size; } }

        public MascotImage Cover { get { return mascot.Cover; } }

        public Manager Manager { get; set; }

        #endregion

        public MascotModel() {
            mascot = Manager.Instance.GetMascot("Irisu");
        }

        public ImageBrush Tick() {
            return mascot.Next();
        }
    }
}
