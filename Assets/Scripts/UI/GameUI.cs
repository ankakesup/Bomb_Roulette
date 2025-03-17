// Assets/Scripts/UI/GameUI.cs
using UnityEngine;
using UnityEngine.UI;

namespace Bomb_Roulette.UI
{
    public class GameUI : MonoBehaviour
    {
        public static GameUI Instance;
        public Text turnDisplayText;
        public Text timerText;
        public GameObject operationsPanel; // 操作説明パネル（常時表示可能）

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
    }
}
