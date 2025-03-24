// Assets/Scripts/Core/TurnManager.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Models;
using Bomb_Roulette.UI;

namespace Bomb_Roulette.Core
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance;
        private int currentTurn = 0; // 現在のターン(Nターン目に対して，N-1の値を取る)
        private int numPlayers = 0; // プレイヤーの人数の管理

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

        public void SetNumPlayers(int numPlayersTemp) // TitleScreenUI からプレイヤーの人数を取得する関数
        {
            numPlayers = numPlayersTemp;

        }

        public int GetNumPlayers() // numPlayers の値を返す関数
        {
            return numPlayers;
        }

        public void NextTurn() // 次のターンにする関数
        {
            currentTurn = currentTurn + 1;
            if (currentTurn == numPlayers) // 全員のターンが終わったらラウンドを更新する
            {
                // 次のaまでのコードで RoundManager の NextRound関数 の呼び出しを行う
                GameObject gameObjectRound = new GameObject("Bomb_Roulette.Core.RoundManager");
                Bomb_Roulette.Core.RoundManager roundManager = gameObjectRound.AddComponent<Bomb_Roulette.Core.RoundManager>();
                roundManager.NextRound();
                // a
                currentTurn = 0; // ラウンドのはじめにcurrentTurnを0にリセットする
            }
            UpdateTurnUI(); // UIの更新
        }

        void UpdateTurnUI()
        {
            Debug.Log("Turn: Player" + (currentTurn + 1));

            if (GameUI.Instance != null)
            {
                GameUI.Instance.UpdateTurnDisplay(currentTurn + 1);
            }
            else
            {
                Debug.LogError("GameUI のインスタンスが見つかりません。シーンに配置されているか確認してください。");
            }
        }

    }
}
