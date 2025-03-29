// Assets/Scripts/UI/GameUI.cs
using UnityEngine;
using UnityEngine.UI;
using Bomb_Roulette.Core;
using TMPro;

namespace Bomb_Roulette.UI
{
    public class GameUI : MonoBehaviour
    {
        public static GameUI Instance;
        public TextMeshProUGUI turnDisplayText;
        public TextMeshProUGUI timerText;
        public TextMeshProUGUI roundDisplayText;
        public Button operationsButton;
        public GameObject operationsPanel; // ��������p�l���i�펞�\���\�j
        public Button TempButton;
        public Button TempButtonTurn;


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
            UpdateTurnDisplay(1);
            UpdateRoundDisplay(1);
            operationsPanel.SetActive(false);
        }

        // UI �̃��E���h�\�����X�V
        public void UpdateRoundDisplay(int currentRound)
        {

            bool isSuddenDeath = RoundManager.Instance.IsSuddenDeath();
            
            if (isSuddenDeath)
            {
                roundDisplayText.text = "Round: " + currentRound;
            }
            else
            {
                roundDisplayText.text = "Final Round";
            }

        }

        public void UpdateTurnDisplay(int numPlayer)
        {
            if (turnDisplayText != null)
            {
                turnDisplayText.text = "Turn: Player" + numPlayer;
            }
            else
            {
                Debug.LogError("turnDisplayText��null�ł��BInspector�ł̐ݒ���m�F���Ă��������B");
            }
        }

        public void UpdateTimerDisplay(float timeRemaining)
        {
            timerText.text = "TimeLimit: " + timeRemaining.ToString("F1");
        }

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }
        

        public void TempButtonClicked() // �f�o�b�O�p��rerult��ʋN���p�֐�
        {
            GameManager.Instance.EndGame();
        }

        public void TempButtonTurnClicked()
        {
            if (TurnManager.Instance != null)
            {
                TurnManager.Instance.NextTurn();
            }
            else
            {
                Debug.LogError("TurnManager �̃C���X�^���X��������܂���B�V�[���ɔz�u����Ă��邩�m�F���Ă��������B");
            }
        }

    }
}
