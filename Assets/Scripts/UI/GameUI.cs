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
        public GameObject operationsPanel; // 操作説明パネル（常時表示可能）
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

        // UI のラウンド表示を更新
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
                Debug.LogError("turnDisplayTextがnullです。Inspectorでの設定を確認してください。");
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
        

        public void TempButtonClicked() // デバッグ用のrerult画面起動用関数
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
                Debug.LogError("TurnManager のインスタンスが見つかりません。シーンに配置されているか確認してください。");
            }
        }

    }
}
