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

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void UpdateTurnDisplay(string playerName)
        {
            turnDisplayText.text = "���݂̃^�[��: " + playerName;
        }

        public void UpdateTimerDisplay(float timeRemaining)
        {
            timerText.text = "�c�莞��: " + timeRemaining.ToString("F1");
        }

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }


        public void TempButtonClicked() // �J������rerult��ʋN���p�֐�
        {
            GameManager.Instance.EndGame();
        }
    }
}
