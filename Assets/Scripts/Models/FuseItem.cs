using UnityEngine;

namespace Bomb_Roulette.Models
{
    public class FuseItem : MonoBehaviour
    {
        private int index;

        /// <summary>
        /// FuseManager �ɂ���ăC���f�b�N�X���ݒ肳���B
        /// </summary>
        public void SetIndex(int idx)
        {
            index = idx;
        }

        // �K�v�ɉ����āAFuseItem �ŗL�̏�����ǉ��\
    }
}