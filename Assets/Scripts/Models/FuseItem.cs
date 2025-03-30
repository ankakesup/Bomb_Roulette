using UnityEngine;
using UnityEngine.EventSystems;

namespace Bomb_Roulette.Models
{
    public class FuseItem : MonoBehaviour
    {
        private int index;

        /// <summary>
        /// FuseItem ������������Bflip��true�̏ꍇ�A���E���]���s���B
        /// �܂��A�N���b�N�C�x���g�������Őݒ肷��B
        /// </summary>
        public void Initialize(int idx, bool flip)
        {
            index = idx;

            if (flip)
            {
                // localScale.x �𕉂ɂ��č��E���]
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }

            // EventTrigger ��ǉ����ăN���b�N�C�x���g��ݒ�
            EventTrigger trigger = GetComponent<EventTrigger>() ?? gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
            entry.callback.AddListener((data) => { FuseManager.Instance.OnFuseClicked(index); });
            trigger.triggers.Add(entry);
        }
    }
}
