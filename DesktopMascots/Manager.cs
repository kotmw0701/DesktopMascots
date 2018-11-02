using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DesktopMascots {
    class Manager {

        #region Singleton

        public static Manager Instance { get; } = new Manager();

        private Manager() { }

        private bool isAlive = false;

        #endregion

        #region 変数

        /// <summary>
        /// 表示中のマスコット
        /// </summary>
        private List<MascotView> _mascots = new List<MascotView>();

        /// <summary>
        /// Mascot全体を動かすSheduler
        /// </summary>
        private Task task = null;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void GenerateMascot() {
            MascotView mascot = new MascotView();
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
            CancellationToken token = CancellationToken.None;
            while(!token.IsCancellationRequested) {
                //引数1 : 遅延処理
                //引数2 : 非同期したい処理の内容
                await Task.WhenAll(Task.Delay(95), Task.Run(() => {
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
                    model.Chara = model.mascot.GetNextImage;
                });
            }
        }
    }
}
