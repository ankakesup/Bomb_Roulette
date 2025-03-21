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
        public Button TempButtonTurn;

        
        public void start()
        {
            UpdateTurnDisplay(1); // UIの更新を行う
            Debug.Log("Game Start"); // デバッグログの出力
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

        public void TempButtonTurnClicked() // デバッグ用のrerult画面起動用関数
        {
            Bomb_Roulette.Core.TurnManager turnManager = new Bomb_Roulette.Core.TurnManager();
            turnManager.NextTurn();
        }
    }
}
