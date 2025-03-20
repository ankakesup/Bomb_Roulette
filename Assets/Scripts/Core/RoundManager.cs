// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        private int currentRound = 1;
        private int maxInitialRounds = 3;

        public void NextRound() // 次のラウンドにする関数
        {
            currentRound++;
            
            if (currentRound > maxInitialRounds) // 4ラウンド目に入ったら，サドンデスにする
            {
                ActivateSuddenDeath();
            }
            else
            {
                // 通常ラウンド用の処理（例：導火線本数の更新など）
            }
            Debug.Log("Round: " + currentRound);
        }

        void ActivateSuddenDeath()
        {
            // サドンデスラウンドのルール適用
            Debug.Log("Start Sudden Death Round!!");
        }
    }
}
