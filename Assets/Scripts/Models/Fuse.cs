// Assets/Scripts/Models/Fuse.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Effects;

namespace Bomb_Roulette.Models
{
    public class Fuse : MonoBehaviour
    {
        public GameObject fusePrefab; // Inspector で Fuse のプレハブをセット
        public Transform fuseParent; // UI の親オブジェクト（Canvas の子オブジェクト）

        private List<Fuse> fuses = new List<Fuse>();

        public void GenerateFuses(int numFuses)
        {
            // 既存の導火線を削除
            foreach (Transform child in fuseParent)
            {
                Destroy(child.gameObject);
            }
            fuses.Clear();

            float spacing = 100f; // 円形配置の半径
            Vector2 startPosition = new Vector2(-spacing * (numFuses - 1) / 2, 0); // 中心からのオフセットを計算

            for (int i = 0; i < numFuses ; i++)
            {
                // 直線上に配置
                Vector2 position = startPosition + new Vector2(i * spacing, 0); // 水平方向に等間隔で配置

                // 導火線の生成
                GameObject fuseObj = Instantiate(fusePrefab, fuseParent);
                fuseObj.GetComponent<RectTransform>().anchoredPosition = position;

                Fuse fuse = fuseObj.GetComponent<Fuse>();
                fuses.Add(fuse);
            }
        }

    }
}
