using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Bomb_Roulette.Core;

namespace Bomb_Roulette.Models
{
    public class FuseManager : MonoBehaviour
    {
        // �V���O���g���C���X�^���X
        public static FuseManager Instance;

        // Inspector �Őݒ肷��v���n�u�Ɛe�I�u�W�F�N�g
        public GameObject fusePrefab;
        public Transform fuseParent;

        // �������ꂽ FuseItem ���Ǘ�����z��
        private FuseItem[] fuseArray;

        private void Awake()
        {
            // �V���O���g��������
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
            RemoveAllFuses(); // ������ Fuse ��S�폜
            fuseArray = new FuseItem[numFuses];

            float spacing = 100f; // �z�u�Ԋu
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0);

            for (int i = 0; i < numFuses; i++)
            {
                // �e Fuse �̈ʒu���v�Z
                Vector2 position = startPosition + new Vector2(i * spacing, 0);

                // Fuse �v���n�u�𐶐����A�e�ɔz�u
                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                // FuseItem �R���|�[�l���g���擾���Ĕz��Ɋi�[
                FuseItem fuseItem = fuseObj.GetComponent<FuseItem>();
                fuseArray[i] = fuseItem;
                // �C���f�b�N�X��ݒ�i�K�v�ɉ����� FuseItem ���ŗ��p�\�j
                fuseItem.SetIndex(i);

                // EventTrigger ��ǉ����A�N���b�N�C�x���g�� Fuse ���폜����悤�ɐݒ�
                EventTrigger trigger = fuseObj.GetComponent<EventTrigger>() ?? fuseObj.AddComponent<EventTrigger>();
                int index = i; // ���[�J���ϐ��ŃL���v�`��
                EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
                entry.callback.AddListener((data) => { OnFuseClicked(index); });
                trigger.triggers.Add(entry);
            }

            // �m�F�p���O�i�e FuseItem �̎Q�Ƃ������Ă��邩�o�́j
            for (int i = 0; i < numFuses; i++)
            {
                Debug.Log(fuseArray[i]);
            }
        }

        /// <summary>
        /// Fuse ���N���b�N���ꂽ�Ƃ��̏����i�w��C���f�b�N�X�� Fuse ���폜�j�B
        /// </summary>
        private void OnFuseClicked(int index)
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

            // fuseParent �z���̎q�I�u�W�F�N�g���S�폜�i�K�v�ȏꍇ�j
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
