using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Bomb_Roulette.Core;

namespace Bomb_Roulette.UI
{
    public class TitleScreenUI : MonoBehaviour
    {
        public Dropdown playerCountDropdown;
        public Button startButton;
        public Button operationsButton;
        public GameObject operationsPanel;
        public GameObject ScreenClickListener;

        void Start()
        {
            operationsButton.onClick.AddListener(OnOperationsButtonClicked);
            operationsPanel.SetActive(false);

            // ScreenClickListener にクリックイベントを追加する処理
            EventTrigger trigger = ScreenClickListener.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = ScreenClickListener.AddComponent<EventTrigger>();
            }
            // PointerClick イベントのエントリを作成
            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick
            };
            entry.callback.AddListener((data) => { OnGameObjectClicked(); });
            trigger.triggers.Add(entry);
        }

        public void OnOperationsButtonClicked()
        {
            operationsPanel.SetActive(!operationsPanel.activeSelf);
        }

        // クリックイベント時に呼ばれるメソッド
        void OnGameObjectClicked()
        {
            TurnManager.Instance.SetNumPlayers(playerCountDropdown.value + 2);
            GameManager.Instance.StartGame();
        }
    }
}
