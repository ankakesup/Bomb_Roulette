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
        private int currentTurn = 0; // ���݂̃^�[��(N�^�[���ڂɑ΂��āCN-1�̒l�����)
        private int numPlayers = 0; // �v���C���[�̐l���̊Ǘ�

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
            currentTurn = currentTurn + 1;
            if (currentTurn == numPlayers) // �S���̃^�[�����I������烉�E���h���X�V����
            {
                // ����a�܂ł̃R�[�h�� RoundManager �� NextRound�֐� �̌Ăяo�����s��
                GameObject gameObjectRound = new GameObject("Bomb_Roulette.Core.RoundManager");
                Bomb_Roulette.Core.RoundManager roundManager = gameObjectRound.AddComponent<Bomb_Roulette.Core.RoundManager>();
                roundManager.NextRound();
                // a
                currentTurn = 0; // ���E���h�̂͂��߂�currentTurn��0�Ƀ��Z�b�g����
            }
            UpdateTurnUI(); // UI�̍X�V
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
                Debug.LogError("GameUI �̃C���X�^���X��������܂���B�V�[���ɔz�u����Ă��邩�m�F���Ă��������B");
            }
        }

    }
}
