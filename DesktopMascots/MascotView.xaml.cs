using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopMascots {
    /// <summary>
    /// MascotView.xaml の相互作用ロジック
    /// (Model) : Mascot.cs
    /// (View) MascotView.xaml.cs
    /// (ViewModel) MascotViewModel.xaml.cs
    /// </summary>
    public partial class MascotView : Window {

        public MascotView(Mascot mascot) {
            //常時最前面
            Topmost = true;

            //マウスドラッグ出来るように
            MouseLeftButtonDown += (sender, e) => DragMove();

            InitializeComponent();

            ((MascotViewModel)DataContext).Init(mascot);
        }

        private void Window_SourceInitialized(object sender, EventArgs e) {
            //真下じゃなくて若干2px上に設定
            Top = SystemParameters.PrimaryScreenHeight - (Height - BorderThickness.Bottom) - 2;
            Left = 0;
        }
    }
}
