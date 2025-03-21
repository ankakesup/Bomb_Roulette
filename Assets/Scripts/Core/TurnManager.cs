// Assets/Scripts/Core/TurnManager.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Models;

namespace Bomb_Roulette.Core
{
    public class TurnManager : MonoBehaviour
    {
        private int currentTurn = 0; // 現在のターン(Nターン目に対して，N-1の値を取る)
        private int numPlayers = 0; // プレイヤーの人数の管理

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
            currentTurn++;
            if (currentTurn == numPlayers) // 全員のターンが終わったらラウンドを更新する
            {
                // 次のaまでのコードで RoundManager の NextRound関数 の呼び出しを行う
                RoundManager roundManager = new RoundManager();
                roundManager.NextRound();
                // a
                currentTurn = 0; // ラウンドのはじめにcurrentTurnを0にリセットする
            }
            UpdateTurnUI(); // UIの更新
        }

        void UpdateTurnUI() // ターンの変更時にUIを更新する関数
        {
            Debug.Log("Turn: Player" + (currentTurn + 1) ); // デバッグログの出力

            // 次のbまでのコードで GameUI の UpdateTurnDisplay関数 の呼び出しを行う
            GameObject gameObject = new GameObject("Bomb_Roulette.UI.GameUI");
            Bomb_Roulette.UI.GameUI gameUI = gameObject.AddComponent<Bomb_Roulette.UI.GameUI>();
            gameUI.UpdateTurnDisplay(currentTurn + 1);
            // b
        }
    }
}
