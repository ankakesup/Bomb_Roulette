// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        private int currentRound = 1;
        private int maxInitialRounds = 3;

        public void NextRound() // ���̃��E���h�ɂ���֐�
        {
            currentRound++;
            
            if (currentRound > maxInitialRounds) // 4���E���h�ڂɓ�������C�T�h���f�X�ɂ���
            {
                ActivateSuddenDeath();
            }
            else
            {
                // �ʏ탉�E���h�p�̏����i��F���ΐ��{���̍X�V�Ȃǁj
            }
            Debug.Log("Round: " + currentRound);
        }

        void ActivateSuddenDeath()
        {
            // �T�h���f�X���E���h�̃��[���K�p
            Debug.Log("Start Sudden Death Round!!");
        }
    }
}
