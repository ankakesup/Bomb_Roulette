// Assets/Scripts/Core/PlayerManager.cs
using UnityEngine;
using System.Collections.Generic;
using BombRoulette.Models;

namespace BombRoulette.Core
{
    public class PlayerManager : MonoBehaviour
    {
        public List<Player> players = new List<Player>();

        public void CreatePlayers(int numberOfPlayers)
        {
            players.Clear();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                // �v���C���[���́u�v���C���[N�v�ŁAN�̓^�[���ԍ��ii+1�j�ƂȂ�
                Player newPlayer = new Player("�v���C���[" + (i + 1), i + 1);
                players.Add(newPlayer);
            }
        }

        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}
