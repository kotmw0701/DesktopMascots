using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesktopMascots {
    class Mascot {

        #region 変数

        public string Name { get; }

        public double Height { get; }
        public double Width { get; }

        public ImageBrush Cover { get; }
        
        private Point anchor;
        private bool lookRight = false;

        private List<ImagePair> imagePairs = new List<ImagePair>();
        #endregion

        public Mascot(string name, List<ImagePair> imagePairs) {
            Name = name;
            this.imagePairs = imagePairs;
            Cover = imagePairs[0].GetImage(lookRight).Image;
            Height = Cover.ImageSource.Height;
            Width = Cover.ImageSource.Width;
        }

        private int count = 0;

        public ImageBrush Next() {
            if (count >= imagePairs.Count)
                count = 0;
            ImagePair imagePair = imagePairs[count++];
            return imagePair.GetImage(lookRight).Image;
        }

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
         *     ↑1フレームずつのこれを合計して，24 Mod 合計値 で求めて
         *       求めた数値から1フレームずつの切り替え時間を引いて行って，0以下になったらそのフレームを返す(=そのフレームの時間)
         *       以下参考ソース，getDurationはDuration(切り替え時間)の合計値
         *       public Pose getPoseAt(int time) {
         *
	     *           time %= getDuration();
         *
	     *           for (final Pose pose : getPoses()) {
		 *               time -= pose.getDuration();
		 *               if (time < 0) {
		 *                    return pose;
		 *               }
	     *           }
         *
	     *           return null;
         *       }
         *   ・座標
         *   ・今右を向いているか (bool)
         *   ・歩き速度 (double)
         *   ・走り速度 (double)
         * 
         * 
         * Mascotクラスに全部のAnimationを保存する？
         * キャラ毎にMascotクラスのインスタンスを生成
         * Modelのインスタンスを生成する段階でMascotクラスを渡す
         * あくまで
         * Mascot.cs : 画像の保存，アニメーションの管理，アニメーションを進める？
         * MascotModel.cs : 切り替え画像の読み込み
         * って感じかな
         * 
         * 11/9 : とりあえず立ち絵のアニメーションオンリーなのでアニメーションクラスは用意しないでImagePair直接叩きます。
         */
    }
}
