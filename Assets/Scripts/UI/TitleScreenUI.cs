// Assets/Scripts/UI/TitleScreenUI.cs

using UnityEngine;
using UnityEngine.UI;
using Bomb_Roulette.Core;

namespace Bomb_Roulette.UI
{
    public class TitleScreenUI : MonoBehaviour
    {
        public Dropdown playerCountDropdown;
        public Button startButton;
        public Button operationsButton;
        public GameObject operationsPanel;

        void Start()
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
            operationsButton.onClick.AddListener(OnOperationsButtonClicked);
            operationsPanel.SetActive(false);
        }

        void OnStartButtonClicked()
        {
            int playerCount = playerCountDropdown.value + 2;
            GameManager.Instance.StartGame();
        }

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }
    }
}
