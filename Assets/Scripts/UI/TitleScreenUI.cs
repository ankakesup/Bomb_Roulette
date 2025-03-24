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
            if (TurnManager.Instance != null)
            {
                TurnManager.Instance.SetNumPlayers(playerCountDropdown.value + 2);
            }
            else
            {
                Debug.LogError("TurnManager �̃C���X�^���X��������܂���B�V�[���ɔz�u����Ă��邱�Ƃ��m�F���Ă��������B");
            }

            GameManager.Instance.StartGame();
        }

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }
    }
}
