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
            GameManager.Instance.StartGame();
            
            GameObject gameObject = new GameObject("Bomb_Roulette.Core.TurnManager");
            Bomb_Roulette.Core.TurnManager turnManager = gameObject.AddComponent<Bomb_Roulette.Core.TurnManager>();
            turnManager.SetNumPlayers(playerCountDropdown.value + 2);
        }

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }
    }
}
