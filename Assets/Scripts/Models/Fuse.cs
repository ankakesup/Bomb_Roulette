// Assets/Scripts/Models/Fuse.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Effects;

namespace Bomb_Roulette.Models
{
    public class Fuse : MonoBehaviour
    {
        public GameObject fusePrefab; // Inspector �� Fuse �̃v���n�u���Z�b�g
        public Transform fuseParent; // UI �̐e�I�u�W�F�N�g�iCanvas �̎q�I�u�W�F�N�g�j

        private List<Fuse> fuses = new List<Fuse>();

        public void GenerateFuses(int numFuses)
        {
            // �����̓��ΐ����폜
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
            fuses.Clear();

            float spacing = 100f; // �~�`�z�u�̔��a
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0); // ���S����̃I�t�Z�b�g���v�Z

            for (int i = 0; i < numFuses ; i++)
            {
                // ������ɔz�u
                Vector2 position = startPosition + new Vector2(i * spacing, 0); // ���������ɓ��Ԋu�Ŕz�u

                // ���ΐ��̐���
                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                Fuse fuse = fuseObj.GetComponent<Fuse>();
                fuses.Add(fuse);
            }
        }

    }
}
