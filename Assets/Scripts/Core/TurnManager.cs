// Assets/Scripts/Core/TurnManager.cs
using UnityEngine;
using System.Collections.Generic;
using BombRoulette.Models;

namespace BombRoulette.Core
{
    public class TurnManager : MonoBehaviour
    {
        public List<Player> players = new List<Player>();
        private int currentTurnIndex = 0;

        public void InitializeTurns(List<Player> playerList)
        {
            players = playerList;
            currentTurnIndex = 0;
            UpdateTurnUI();
        }

        public Player GetCurrentPlayer()
        {
            return players[currentTurnIndex];
        }

        public void NextTurn()
        {
            currentTurnIndex = (currentTurnIndex + 1) % players.Count;
            UpdateTurnUI();
        }

        void UpdateTurnUI()
        {
            // UIの更新例。GameUI.Instance.UpdateTurnDisplay などを呼び出す
            Debug.Log("現在のターン: " + GetCurrentPlayer().playerName);
        }
    }
}
