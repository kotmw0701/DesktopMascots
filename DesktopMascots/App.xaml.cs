﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
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

            LoadConfiguration();

            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            this.notifyIcon = new NotifyIconWrapper();
            List<Pose> poses = new List<Pose>();
            for (int i = 0; i < 6; i++) {
                ImagePair imagePair = ImagePairLoader.Load(@"C:\Sync\gif\irisu\3px\rabiribi_iris_page" + (i + 1) + ".png");
                Pose pose = new Pose(imagePair, 6);
                poses.Add(pose);
            }
            Animation animation = new Animation(poses.ToArray());
            Mascot mascot = new Mascot(animation);
            MascotView view = new MascotView(mascot);
            view.Show();
            var token = CancellationToken.None;
            while (true) {
                await Task.WhenAll(Task.Delay(1), Task.Run(() => {
                    mascot.Tick();
                }, token));
            }


            //CreateFirst();
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
        }
    }
}
