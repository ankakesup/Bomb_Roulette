// Assets/Scripts/Core/TurnManager.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Models;

namespace Bomb_Roulette.Core
{
    public class TurnManager : MonoBehaviour
    {
        private int currentTurn = 0;
        private int numPlayers = 0;

        public void GetNumPlayers(int numPlayersTemp) // TitleScreenUI からプレイヤーの人数を取得する
        {
            numPlayers = numPlayersTemp;
            UpdateTurnUI();
        }

        public void NextTurn() // 次のターンにする関数
        {
            currentTurn++;
            if (currentTurn == numPlayers) // 全員のターンが終わったらラウンドを更新する
            {
                RoundManager roundManager = new RoundManager();
                roundManager.NextRound();
                currentTurn = 0;
            }
            UpdateTurnUI();
        }

        void UpdateTurnUI() // ターンの変更時にUIを更新する関数
        {
            // UIの更新例。GameUI.Instance.UpdateTurnDisplay などを呼び出す
            Debug.Log("Turn: Player" + (currentTurn + 1) );

            GameObject gameObject = new GameObject("Bomb_Roulette.UI.GameUI");
            Bomb_Roulette.UI.GameUI gameUI = gameObject.AddComponent<Bomb_Roulette.UI.GameUI>();
            gameUI.UpdateTurnDisplay(currentTurn + 1);
        }
    }
}
