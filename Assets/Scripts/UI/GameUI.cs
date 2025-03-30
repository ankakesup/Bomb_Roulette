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
        public TextMeshProUGUI roundDisplayText;
        public Button operationsButton;
        public Button operationsButton2;
        public GameObject operationsPanel; // ��������p�l���i�펞�\���\�j


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
                roundDisplayText.text = "Final Round";
            }
            else
            {
                roundDisplayText.text = "Round: " + currentRound;
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

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }
    }
}
