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

            // ScreenClickListener �ɃN���b�N�C�x���g��ǉ����鏈��
            EventTrigger trigger = ScreenClickListener.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = ScreenClickListener.AddComponent<EventTrigger>();
            }
            // PointerClick �C�x���g�̃G���g�����쐬
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

        // �N���b�N�C�x���g���ɌĂ΂�郁�\�b�h
        void OnGameObjectClicked()
        {
            TurnManager.Instance.SetNumPlayers(playerCountDropdown.value + 2);
            GameManager.Instance.StartGame();
        }
    }
}
