// Assets/Scripts/Core/PlayerManager.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Models;

namespace Bomb_Roulette.Core
{
    public class PlayerManager : MonoBehaviour
    {
        public List<Player> players = new List<Player>();

        public void CreatePlayers(int numberOfPlayers)
        {
            players.Clear();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                // プレイヤー名は「プレイヤーN」で、Nはターン番号（i+1）となる
                Player newPlayer = new Player("プレイヤー" + (i + 1), i + 1);
                players.Add(newPlayer);
            }
        }

        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}
