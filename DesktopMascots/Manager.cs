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
        /// マスコットの種類のデータ
        /// </summary>
        private Dictionary<string, Mascot> mascotData = new Dictionary<string, Mascot>();

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
        /// マスコットのデータを登録する
        /// </summary>
        /// <returns>既に同じ名前のキャラがいればfalse</returns>
        public bool RegisterMascot(Mascot mascot) {
            if (mascotData.ContainsKey(mascot.Name))
                return false;
            mascotData[mascot.Name] = mascot;
            return true;
        }


        public Mascot GetMascot(string name) {
            return mascotData[name];
        }

        /// <summary>
        /// マスコットを生成する
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
                    foreach (MascotView mascot in _mascots) {
                        mascot.Dispatcher.Invoke(() => {
                            if (!(mascot.DataContext is MascotViewModel model))
                                return;
                            model.Tick();
                        });
                    }
                }, token));
            }
        }
    }
}
