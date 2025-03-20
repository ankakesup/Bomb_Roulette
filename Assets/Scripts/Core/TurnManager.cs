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

        public void GetNumPlayers(int numPlayersTemp) // TitleScreenUI ����v���C���[�̐l�����擾����
        {
            numPlayers = numPlayersTemp;
            UpdateTurnUI();
        }

        public void NextTurn() // ���̃^�[���ɂ���֐�
        {
            currentTurn++;
            if (currentTurn == numPlayers) // �S���̃^�[�����I������烉�E���h���X�V����
            {
                RoundManager roundManager = new RoundManager();
                roundManager.NextRound();
                currentTurn = 0;
            }
            UpdateTurnUI();
        }

        void UpdateTurnUI() // �^�[���̕ύX����UI���X�V����֐�
        {
            // UI�̍X�V��BGameUI.Instance.UpdateTurnDisplay �Ȃǂ��Ăяo��
            Debug.Log("Turn: Player" + (currentTurn + 1) );

            GameObject gameObject = new GameObject("Bomb_Roulette.UI.GameUI");
            Bomb_Roulette.UI.GameUI gameUI = gameObject.AddComponent<Bomb_Roulette.UI.GameUI>();
            gameUI.UpdateTurnDisplay(currentTurn + 1);
        }
    }
}
