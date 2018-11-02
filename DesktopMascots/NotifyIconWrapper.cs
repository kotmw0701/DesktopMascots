using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopMascots
{
    /// <summary>
    /// タスクアイコン
    /// </summary>
    public partial class NotifyIconWrapper: Component
    {    
        public NotifyIconWrapper()
        {
            InitializeComponent();

            this.toolStripMenuItem_Open.Click += this.toolStripMenuItem_Open_Click;
            this.toolStripMenuItem_Exit.Click += this.toolStripMenuItem_Exit_Click;
        }

        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// "表示"がクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Open_Click(Object sender, EventArgs e) {
            Manager.Instance.GenerateMascot();
        }

        /// <summary>
        /// "終了"がクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Exit_Click(Object sender, EventArgs e) {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// アイコンがダブルクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            Manager.Instance.GenerateMascot();
        }
    }
}
