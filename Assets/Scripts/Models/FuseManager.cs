using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Bomb_Roulette.Core;

namespace Bomb_Roulette.Models
{
    public class FuseManager : MonoBehaviour
    {
        public static FuseManager Instance { get; private set; }

        // Inspector �Őݒ肷��v���n�u�Ɛe�I�u�W�F�N�g
        public GameObject fusePrefab;
        public Transform fuseParent;

        // �������ꂽ FuseItem ���Ǘ�����z��
        private FuseItem[] fuseArray;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        /// <summary>
        /// �w�肵������ Fuse �𐶐�����i������ Fuse �͍폜�j�B
        /// </summary>
        public void GenerateFuses(int numFuses)
        {
            RemoveAllFuses();
            fuseArray = new FuseItem[numFuses];

            float spacing = 200f;
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0);
            // ������ Fuse �̌��F(numFuses / 2) + (numFuses % 2)
            int rightStartIndex = (numFuses / 2) + (numFuses % 2);

            for (int i = 0; i < numFuses; i++)
            {
                Vector2 position = startPosition + new Vector2(i * spacing, 0);
                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                FuseItem fuseItem = fuseObj.GetComponent<FuseItem>();
                fuseArray[i] = fuseItem;

                // �e FuseItem ���������B�E�����̏ꍇ�͌ʂɔ��]����
                bool shouldFlip = i >= rightStartIndex;
                fuseItem.Initialize(i, shouldFlip);
            }
        }

        /// <summary>
        /// Fuse ���N���b�N���ꂽ�Ƃ��̏����i�w��C���f�b�N�X�� Fuse ���폜�j�B
        /// </summary>
        public void OnFuseClicked(int index)
        {
            Debug.Log($"Fuse clicked at index {index}. Removing...");
            RemoveFuse(index);

            if (!TurnManager.Instance.CheckForExplosion())
            {
                TurnManager.Instance.NextTurn();
            }
        }

        /// <summary>
        /// �w�肵���C���f�b�N�X�� Fuse ���폜����B
        /// </summary>
        public void RemoveFuse(int index)
        {
            if (fuseArray != null && index >= 0 && index < fuseArray.Length && fuseArray[index] != null)
            {
                Destroy(fuseArray[index].gameObject);
                fuseArray[index] = null;
            }
        }

        /// <summary>
        /// �������ꂽ���ׂĂ� Fuse ���폜����B
        /// </summary>
        public void RemoveAllFuses()
        {
            if (fuseArray != null)
            {
                foreach (FuseItem fuse in fuseArray)
                {
                    if (fuse != null)
                    {
                        Destroy(fuse.gameObject);
                    }
                }
                fuseArray = null;
            }

            // fuseParent �z���̎q�I�u�W�F�N�g���S�폜
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
