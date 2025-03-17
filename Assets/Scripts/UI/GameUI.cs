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
        public GameObject operationsPanel; // ��������p�l���i�펞�\���\�j

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
    }
}
