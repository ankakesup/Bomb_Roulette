// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;
using Bomb_Roulette.Models;
using Bomb_Roulette.UI;
using System.Collections;

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
            }

            // 導火線を削除してから新しい導火線を生成
            StartCoroutine(GenerateFusesAfterDelay(numPlayers));

            Debug.Log("Round: " + currentRound); // デバッグログの出力
            UpdateRoundUI();
        }

        private IEnumerator GenerateFusesAfterDelay(int numFuses)
        {
            yield return new WaitForSeconds(0.5f); // 0.5秒待機（削除が完了するのを待つ）

            if (isSuddenDeath)
            {
                FuseManager.Instance.GenerateFuses(numFuses); // サドンデスでは通常の本数
            }
            else
            {
                FuseManager.Instance.GenerateFuses(numFuses + 1); // 通常ラウンドでは+1本
            }
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
