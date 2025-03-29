// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;
using Bomb_Roulette.Models;
using Bomb_Roulette.UI;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        public static RoundManager Instance;
        private int currentRound = 1; // ���݂̃��E���h�̊Ǘ�
        private int maxInitialRounds = 3; // �ʏ탉�E���h���s���ő吔
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
            isSuddenDeath = false; // �T�h���f�X��Ԃ����Z�b�g
            TurnManager.Instance.ResetTurn();
        }

        public void NextRound() // ���̃��E���h�ɂ���֐�
        {
            currentRound++;

            int numPlayers = TurnManager.Instance.GetNumPlayers();

            if (currentRound > maxInitialRounds) // 4���E���h�ڂɓ�������C�T�h���f�X�ɂ���
            {
                ActivateSuddenDeath();
                FuseManager.Instance.GenerateFuses(numPlayers);
            }
            else
            {
                // �ʏ탉�E���h�p�̏����������Ăق����i��F���ΐ��{���̍X�V�Ȃǁj
                FuseManager.Instance.GenerateFuses(numPlayers + 1);
            }
            Debug.Log("Round: " + currentRound); // �f�o�b�O���O�̏o��
            UpdateRoundUI();
        }

        void ActivateSuddenDeath()
        {
            // �T�h���f�X���E���h�̃��[���K�p
            Debug.Log("Start Sudden Death Round!!"); // �f�o�b�O���O�̏o��
            isSuddenDeath = true;
        }

        public bool IsSuddenDeath()
        {
            return isSuddenDeath;
        }

        // UI �̃��E���h�\�����X�V
        private void UpdateRoundUI()
        {
            if (GameUI.Instance != null)
            {
                GameUI.Instance.UpdateRoundDisplay(currentRound);
            }

        }    
    }
}
