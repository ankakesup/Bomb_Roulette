using UnityEngine;

namespace Bomb_Roulette.Models
{
    public class FuseItem : MonoBehaviour
    {
        private int index;

        /// <summary>
        /// FuseManager によってインデックスが設定される。
        /// </summary>
        public void SetIndex(int idx)
        {
            index = idx;
        }

        // 必要に応じて、FuseItem 固有の処理を追加可能
    }
}