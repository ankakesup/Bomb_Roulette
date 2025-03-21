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
        [SerializeField] public TMP_Text turnDisplayText;
        [SerializeField] public TMP_Text timerText;
        public Button operationsButton;
        public GameObject operationsPanel; // ��������p�l���i�펞�\���\�j
        public Button TempButton;
        public Button TempButtonTurn;

        
        public void start()
        {
            UpdateTurnDisplay(1); // UI�̍X�V���s��
            Debug.Log("Game Start"); // �f�o�b�O���O�̏o��
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

        public void TempButtonTurnClicked() // �f�o�b�O�p��rerult��ʋN���p�֐�
        {
            Bomb_Roulette.Core.TurnManager turnManager = new Bomb_Roulette.Core.TurnManager();
            turnManager.NextTurn();
        }
    }
}
