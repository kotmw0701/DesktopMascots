using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascots {
    interface IAction {

        /// <summary>
        /// このアクションをするMascotを登録する
        /// </summary>
        void Init();

        /// <summary>
        /// 次のフレームがあるかどうか
        /// </summary>
        /// <returns>次のフレームがあればtrue</returns>
        bool HasNext();

        /// <summary>
        /// 切り替える
        /// </summary>
        void Next();
    }
}
