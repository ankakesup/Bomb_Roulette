using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Bomb_Roulette.Core;

namespace Bomb_Roulette.Models
{
    public class FuseManager : MonoBehaviour
    {
        // シングルトンインスタンス
        public static FuseManager Instance;

        // Inspector で設定するプレハブと親オブジェクト
        public GameObject fusePrefab;
        public Transform fuseParent;

        // 生成された FuseItem を管理する配列
        private FuseItem[] fuseArray;

        private void Awake()
        {
            // シングルトン初期化
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
        /// 指定した数の Fuse を生成する（既存の Fuse は削除）。
        /// </summary>
        public void GenerateFuses(int numFuses)
        {
            RemoveAllFuses(); // 既存の Fuse を全削除
            fuseArray = new FuseItem[numFuses];

            float spacing = 100f; // 配置間隔
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0);

            for (int i = 0; i < numFuses; i++)
            {
                // 各 Fuse の位置を計算
                Vector2 position = startPosition + new Vector2(i * spacing, 0);

                // Fuse プレハブを生成し、親に配置
                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                // FuseItem コンポーネントを取得して配列に格納
                FuseItem fuseItem = fuseObj.GetComponent<FuseItem>();
                fuseArray[i] = fuseItem;
                // インデックスを設定（必要に応じて FuseItem 内で利用可能）
                fuseItem.SetIndex(i);

                // EventTrigger を追加し、クリックイベントで Fuse を削除するように設定
                EventTrigger trigger = fuseObj.GetComponent<EventTrigger>() ?? fuseObj.AddComponent<EventTrigger>();
                int index = i; // ローカル変数でキャプチャ
                EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
                entry.callback.AddListener((data) => { OnFuseClicked(index); });
                trigger.triggers.Add(entry);
            }

            // 確認用ログ（各 FuseItem の参照が入っているか出力）
            for (int i = 0; i < numFuses; i++)
            {
                Debug.Log(fuseArray[i]);
            }
        }

        /// <summary>
        /// Fuse がクリックされたときの処理（指定インデックスの Fuse を削除）。
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
        /// 指定したインデックスの Fuse を削除する。
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
        /// 生成されたすべての Fuse を削除する。
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

            // fuseParent 配下の子オブジェクトも全削除（必要な場合）
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
