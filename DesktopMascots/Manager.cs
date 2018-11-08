using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DesktopMascots {
    class Manager {

        #region Singleton

        public static Manager Instance { get; } = new Manager();

        private Manager() {
            Window owner = new Window {
                WindowStyle = WindowStyle.ToolWindow,
                ShowInTaskbar = false,
                Left = -100,
                Height = 0,
                Width = 0
            };
            owner.Show();
            ownerWindow = owner;
        }

        #endregion

        #region 変数

        /// <summary>
        /// 表示中のマスコット
        /// </summary>
        private List<MascotView> _mascots = new List<MascotView>();

        /// <summary>
        /// 定周期処理
        /// </summary>
        private readonly int interval = 90;

        /// <summary>
        /// 定周期処理が始まってるか
        /// </summary>
        private bool isAlive = false;

        /// <summary>
        /// MascotViewをalt + tabで表示させないようにするためのOwner
        /// </summary>
        private readonly Window ownerWindow;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void GenerateMascot() {
            MascotView mascot = new MascotView();
            mascot.Owner = ownerWindow;
            mascot.Show();
            _mascots.Add(mascot);
        }

        /// <summary>
        /// マスコット全体のScheduler
        /// </summary>
        public async Task Start() {
            if (isAlive)
                return;
            isAlive = true;
            //スケジューラーをキャンセルするToken(？)
            var token = CancellationToken.None;
            while(!token.IsCancellationRequested) {
                //引数1 : 遅延処理
                //引数2 : 非同期したい処理の内容
                await Task.WhenAll(Task.Delay(interval), Task.Run(() => {
                    Tick();
                }, token));
            }
        }

        /// <summary>
        /// マスコットを1フレーム進めるしょり
        /// </summary>
        public void Tick() {
            foreach(MascotView mascot in _mascots) {
                mascot.Dispatcher.Invoke(() => {
                    if (!(mascot.DataContext is MascotViewModel model))
                        return;
                    model.Tick();
                });
            }
        }
    }
}
