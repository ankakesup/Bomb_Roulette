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
        public GameObject operationsPanel; // 操作説明パネル（常時表示可能）
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
            turnDisplayText.text = "現在のターン: " + playerName;
        }

        public void UpdateTimerDisplay(float timeRemaining)
        {
            timerText.text = "残り時間: " + timeRemaining.ToString("F1");
        }

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }


        public void TempButtonClicked() // 開発中のrerult画面起動用関数
        {
            GameManager.Instance.EndGame();
        }
    }
}
