// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        private int currentRound = 1; // 現在のラウンドの管理
        private int maxInitialRounds = 3; // 通常ラウンドを行う最大数
        private bool isSuddenDeath = false;

        public void ResetRound()
        {
            currentRound = 1;
            isSuddenDeath = false; // サドンデス状態をリセット
        }

        public void NextRound() // 次のラウンドにする関数
        {
            currentRound++;
            
            if (currentRound > maxInitialRounds) // 4ラウンド目に入ったら，サドンデスにする
            {
                ActivateSuddenDeath();
            }
            else
            {
                // 通常ラウンド用の処理を書いてほしい（例：導火線本数の更新など）
            }
            Debug.Log("Round: " + currentRound); // デバッグログの出力
        }

        void ActivateSuddenDeath()
        {
            // サドンデスラウンドのルール適用
            Debug.Log("Start Sudden Death Round!!"); // デバッグログの出力
            isSuddenDeath = true;
        }

        public bool IsSuddenDeath()
        {
            return isSuddenDeath;
        }
    }
}
