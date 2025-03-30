// Assets/Scripts/UI/ResultScreenUI.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Bomb_Roulette.Core;
using TMPro;

namespace Bomb_Roulette.UI
{
    public class ResultScreenUI : MonoBehaviour
    {
        [SerializeField] public TMP_Text resultText;
        public Button restartButton;

        void Start()
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            ShowResult();
        }

        void ShowResult()
        {
            int explodedPlayer = TurnManager.Instance.GetExplodedPlayer();
            resultText.text = "Player " + (explodedPlayer + 1) ;
        }

        public void OnRestartButtonClicked()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
