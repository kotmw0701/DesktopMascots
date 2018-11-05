using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesktopMascots {
    class Mascot {

        public string Name { get; set; }

        public List<BitmapImage> list = new List<BitmapImage>();

        /* メモ:
         * 全部readonly？
         * 設定変更した場合はキャラ全部再読み込み・・・？ ← 検討
         * とりあえずreadonlyはなしでget/set両方置く
         *   必要なもの
         *   ・マスコットの名前 (string)
         *   ・画像ファイル各種 (BitmapImage)
         *   　・立ち状態     1<=n枚
         *   　・歩き状態     1<=n枚
         *   　・走り状態     上記と併用可能に
         *   　・落下中状態   0<=n枚    (設定が無い場合は立ち状態を使用する)
         *   　・その他遊びアクション各種
         *   　  ・ぶつかる？
         *   　  ・会話？
         *   　  ・未定
         *   ・フレーム切り替え時間 (int)
         *   ・座標
         *   ・今右を向いているか (bool)
         *   ・歩き速度 (double)
         *   ・走り速度 (double)
         * 
         */
    }
}
