using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bomb_Roulette.Models
{
    public class Fuse : MonoBehaviour
    {
        // シングルトンインスタンス
        public static Fuse Instance;

        // InspectorでFuseのプレハブと親オブジェクトをセット
        public GameObject fusePrefab;
        public Transform fuseParent;

        // Fuseを配列で管理
        private Fuse[] fuseArray;

        private void Awake()
        {
            // シングルトンのセットアップ
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject); // 既にインスタンスが存在する場合は破棄
                return;
            }
        }

        /// <summary>
        /// 指定した数のFuseを生成する（既存のFuseは削除）。
        /// </summary>
        public void GenerateFuses(int numFuses)
        {
            RemoveAllFuses(); // 既存のFuseを全削除
            fuseArray = new Fuse[numFuses];

            float spacing = 100f; // 配置間隔
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0);

            for (int i = 0; i < numFuses; i++)
            {
                Vector2 position = startPosition + new Vector2(i * spacing, 0);

                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                Fuse fuse = fuseObj.GetComponent<Fuse>();
                fuseArray[i] = fuse;

                // EventTriggerを追加してクリックイベントを設定
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
        /// Fuseがクリックされた時の処理（指定インデックスのFuseを削除）。
        /// </summary>
        private void OnFuseClicked(int index)
        {
            Debug.Log($"Fuse clicked at index {index} and will be removed.");
            RemoveFuse(index);
        }

        /// <summary>
        /// 指定されたインデックスのFuseを削除する。
        /// </summary>
        public void RemoveFuse(int index)
        {
            if (fuseArray[index] == null)
            {
                Debug.Log("Null");
            }

            if (fuseArray != null && index >= 0 && index < fuseArray.Length && fuseArray[index] != null)
            {
                GameObject fuseObj = fuseArray[index].gameObject; // 削除対象のGameObjectを取得
                Destroy(fuseObj);  // GameObjectを削除
                fuseArray[index] = null; // 配列の参照をクリア
            }
        }

        /// <summary>
        /// すべてのFuseを削除する。
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

            // fuseParent内の子オブジェクトも全削除
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
