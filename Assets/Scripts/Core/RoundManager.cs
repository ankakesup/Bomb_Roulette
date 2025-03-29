// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;
using Bomb_Roulette.Models;
using Bomb_Roulette.UI;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        public static RoundManager Instance;
        private int currentRound = 1; // 現在のラウンドの管理
        private int maxInitialRounds = 3; // 通常ラウンドを行う最大数
        private bool isSuddenDeath = false;

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

        public void ResetRound()
        {
            currentRound = 1;
            isSuddenDeath = false; // サドンデス状態をリセット
            TurnManager.Instance.ResetTurn();
        }

        public void NextRound() // 次のラウンドにする関数
        {
            currentRound++;

            int numPlayers = TurnManager.Instance.GetNumPlayers();

            if (currentRound > maxInitialRounds) // 4ラウンド目に入ったら，サドンデスにする
            {
                ActivateSuddenDeath();
                FuseManager.Instance.GenerateFuses(numPlayers);
            }
            else
            {
                // 通常ラウンド用の処理を書いてほしい（例：導火線本数の更新など）
                FuseManager.Instance.GenerateFuses(numPlayers + 1);
            }
            Debug.Log("Round: " + currentRound); // デバッグログの出力
            UpdateRoundUI();
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

        // UI のラウンド表示を更新
        private void UpdateRoundUI()
        {
            if (GameUI.Instance != null)
            {
                GameUI.Instance.UpdateRoundDisplay(currentRound);
            }

        }    
    }
}
