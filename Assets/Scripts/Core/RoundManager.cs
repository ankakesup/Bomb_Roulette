// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        public int currentRound = 1;
        public int maxInitialRounds = 3;

        public void NextRound()
        {
            currentRound++;
            if (currentRound > maxInitialRounds)
            {
                ActivateSuddenDeath();
            }
            else
            {
                // 通常ラウンド用の処理（例：導火線本数の更新など）
            }
            Debug.Log("現在のラウンド: " + currentRound);
        }

        void ActivateSuddenDeath()
        {
            // サドンデスラウンドのルール適用
            Debug.Log("サドンデスラウンド開始！");
        }
    }
}
