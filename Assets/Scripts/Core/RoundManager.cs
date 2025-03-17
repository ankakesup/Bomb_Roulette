// Assets/Scripts/Core/RoundManager.cs
using UnityEngine;

namespace Bomb_Roulette.Core
{
    public class RoundManager : MonoBehaviour
    {
        public int currentRound = 1;
        public int maxInitialRounds = 3;

        public void NextRound()
        {
            currentRound++;
            if (currentRound > maxInitialRounds)
            {
                ActivateSuddenDeath();
            }
            else
            {
                // �ʏ탉�E���h�p�̏����i��F���ΐ��{���̍X�V�Ȃǁj
            }
            Debug.Log("���݂̃��E���h: " + currentRound);
        }

        void ActivateSuddenDeath()
        {
            // �T�h���f�X���E���h�̃��[���K�p
            Debug.Log("�T�h���f�X���E���h�J�n�I");
        }
    }
}
