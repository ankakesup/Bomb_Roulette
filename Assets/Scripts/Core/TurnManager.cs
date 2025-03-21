// Assets/Scripts/Core/TurnManager.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Models;

namespace Bomb_Roulette.Core
{
    public class TurnManager : MonoBehaviour
    {
        private int currentTurn = 0; // ���݂̃^�[��(N�^�[���ڂɑ΂��āCN-1�̒l�����)
        private int numPlayers = 0; // �v���C���[�̐l���̊Ǘ�

        public void SetNumPlayers(int numPlayersTemp) // TitleScreenUI ����v���C���[�̐l�����擾����֐�
        {
            numPlayers = numPlayersTemp;
        }

        public int GetNumPlayers() // numPlayers �̒l��Ԃ��֐�
        {
            return numPlayers;
        }

        public void NextTurn() // ���̃^�[���ɂ���֐�
        {
            currentTurn++;
            if (currentTurn == numPlayers) // �S���̃^�[�����I������烉�E���h���X�V����
            {
                // ����a�܂ł̃R�[�h�� RoundManager �� NextRound�֐� �̌Ăяo�����s��
                RoundManager roundManager = new RoundManager();
                roundManager.NextRound();
                // a
                currentTurn = 0; // ���E���h�̂͂��߂�currentTurn��0�Ƀ��Z�b�g����
            }
            UpdateTurnUI(); // UI�̍X�V
        }

        void UpdateTurnUI() // �^�[���̕ύX����UI���X�V����֐�
        {
            Debug.Log("Turn: Player" + (currentTurn + 1) ); // �f�o�b�O���O�̏o��

            // ����b�܂ł̃R�[�h�� GameUI �� UpdateTurnDisplay�֐� �̌Ăяo�����s��
            GameObject gameObject = new GameObject("Bomb_Roulette.UI.GameUI");
            Bomb_Roulette.UI.GameUI gameUI = gameObject.AddComponent<Bomb_Roulette.UI.GameUI>();
            gameUI.UpdateTurnDisplay(currentTurn + 1);
            // b
        }
    }
}
