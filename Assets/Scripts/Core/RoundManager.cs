// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        private int currentRound = 1; // ���݂̃��E���h�̊Ǘ�
        private int maxInitialRounds = 3; // �ʏ탉�E���h���s���ő吔
        private bool isSuddenDeath = false;

        public void ResetRound()
        {
            currentRound = 1;
            isSuddenDeath = false; // �T�h���f�X��Ԃ����Z�b�g
        }

        public void NextRound() // ���̃��E���h�ɂ���֐�
        {
            currentRound++;
            
            if (currentRound > maxInitialRounds) // 4���E���h�ڂɓ�������C�T�h���f�X�ɂ���
            {
                ActivateSuddenDeath();
            }
            else
            {
                // �ʏ탉�E���h�p�̏����������Ăق����i��F���ΐ��{���̍X�V�Ȃǁj
            }
            Debug.Log("Round: " + currentRound); // �f�o�b�O���O�̏o��
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
    }
}
