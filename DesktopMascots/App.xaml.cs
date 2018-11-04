using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopMascots {
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application {

        private NotifyIconWrapper notifyIcon;

        /// <summary>
        /// アプリケーション起動時処理
        /// トレイアイコンとかの生成
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            this.notifyIcon = new NotifyIconWrapper();
            CreateFirst();
            await Manager.Instance.Start();
        }

        /// <summary>
        /// 終了時処理
        /// 終了時処理
        /// トレイアイコンの削除
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e) {
            base.OnExit(e);
            this.notifyIcon.Dispose();
        }

        /// <summary>
        /// 設定ファイルの読み込み
        /// ./settings/setting.json
        /// </summary>
        private void LoadConfiguration() {

        }

        /// <summary>
        /// 一番最初のマスコットを生成する
        /// </summary>
        private void CreateFirst() {
            Manager.Instance.GenerateMascot();
        }
    }
}
