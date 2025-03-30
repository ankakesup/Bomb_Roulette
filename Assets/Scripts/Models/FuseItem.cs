using UnityEngine;
using UnityEngine.EventSystems;

namespace Bomb_Roulette.Models
{
    public class FuseItem : MonoBehaviour
    {
        private int index;

        /// <summary>
        /// FuseItem を初期化する。flipがtrueの場合、左右反転を行う。
        /// また、クリックイベントもここで設定する。
        /// </summary>
        public void Initialize(int idx, bool flip)
        {
            index = idx;

            if (flip)
            {
                // localScale.x を負にして左右反転
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }

            // EventTrigger を追加してクリックイベントを設定
            EventTrigger trigger = GetComponent<EventTrigger>() ?? gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
            entry.callback.AddListener((data) => { FuseManager.Instance.OnFuseClicked(index); });
            trigger.triggers.Add(entry);
        }
    }
}
