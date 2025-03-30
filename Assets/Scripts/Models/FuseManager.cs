using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Bomb_Roulette.Core;

namespace Bomb_Roulette.Models
{
    public class FuseManager : MonoBehaviour
    {
        public static FuseManager Instance { get; private set; }

        // Inspector で設定するプレハブと親オブジェクト
        public GameObject fusePrefab;
        public Transform fuseParent;

        // 生成された FuseItem を管理する配列
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
        /// 指定した数の Fuse を生成する（既存の Fuse は削除）。
        /// </summary>
        public void GenerateFuses(int numFuses)
        {
            RemoveAllFuses();
            fuseArray = new FuseItem[numFuses];

            float spacing = 200f;
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0);
            // 左側の Fuse の個数：(numFuses / 2) + (numFuses % 2)
            int rightStartIndex = (numFuses / 2) + (numFuses % 2);

            for (int i = 0; i < numFuses; i++)
            {
                Vector2 position = startPosition + new Vector2(i * spacing, 0);
                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                FuseItem fuseItem = fuseObj.GetComponent<FuseItem>();
                fuseArray[i] = fuseItem;

                // 各 FuseItem を初期化。右半分の場合は個別に反転する
                bool shouldFlip = i >= rightStartIndex;
                fuseItem.Initialize(i, shouldFlip);
            }
        }

        /// <summary>
        /// Fuse がクリックされたときの処理（指定インデックスの Fuse を削除）。
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

            // fuseParent 配下の子オブジェクトも全削除
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
