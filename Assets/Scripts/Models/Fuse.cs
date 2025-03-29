using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bomb_Roulette.Models
{
    public class Fuse : MonoBehaviour
    {
        // �V���O���g���C���X�^���X
        public static Fuse Instance;

        // Inspector��Fuse�̃v���n�u�Ɛe�I�u�W�F�N�g���Z�b�g
        public GameObject fusePrefab;
        public Transform fuseParent;

        // Fuse��z��ŊǗ�
        private Fuse[] fuseArray;

        private void Awake()
        {
            // �V���O���g���̃Z�b�g�A�b�v
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject); // ���ɃC���X�^���X�����݂���ꍇ�͔j��
                return;
            }
        }

        /// <summary>
        /// �w�肵������Fuse�𐶐�����i������Fuse�͍폜�j�B
        /// </summary>
        public void GenerateFuses(int numFuses)
        {
            RemoveAllFuses(); // ������Fuse��S�폜
            fuseArray = new Fuse[numFuses];

            float spacing = 100f; // �z�u�Ԋu
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0);

            for (int i = 0; i < numFuses; i++)
            {
                Vector2 position = startPosition + new Vector2(i * spacing, 0);

                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                Fuse fuse = fuseObj.GetComponent<Fuse>();
                fuseArray[i] = fuse;

                // EventTrigger��ǉ����ăN���b�N�C�x���g��ݒ�
                EventTrigger trigger = fuseObj.GetComponent<EventTrigger>() ?? fuseObj.AddComponent<EventTrigger>();
                int index = i;
                EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
                entry.callback.AddListener((data) => { OnFuseClicked(index); });
                trigger.triggers.Add(entry);
            }

            for (int i = 0; i < 3; i++)
            {
                Debug.Log(fuseArray[i]);
            }
        }

        /// <summary>
        /// Fuse���N���b�N���ꂽ���̏����i�w��C���f�b�N�X��Fuse���폜�j�B
        /// </summary>
        private void OnFuseClicked(int index)
        {
            Debug.Log($"Fuse clicked at index {index} and will be removed.");
            RemoveFuse(index);
        }

        /// <summary>
        /// �w�肳�ꂽ�C���f�b�N�X��Fuse���폜����B
        /// </summary>
        public void RemoveFuse(int index)
        {
            if (fuseArray[index] == null)
            {
                Debug.Log("Null");
            }

            if (fuseArray != null && index >= 0 && index < fuseArray.Length && fuseArray[index] != null)
            {
                GameObject fuseObj = fuseArray[index].gameObject; // �폜�Ώۂ�GameObject���擾
                Destroy(fuseObj);  // GameObject���폜
                fuseArray[index] = null; // �z��̎Q�Ƃ��N���A
            }
        }

        /// <summary>
        /// ���ׂĂ�Fuse���폜����B
        /// </summary>
        public void RemoveAllFuses()
        {
            if (fuseArray != null)
            {
                foreach (Fuse fuse in fuseArray)
                {
                    if (fuse != null)
                    {
                        Destroy(fuse.gameObject);
                    }
                }
                fuseArray = null;
            }

            // fuseParent���̎q�I�u�W�F�N�g���S�폜
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
