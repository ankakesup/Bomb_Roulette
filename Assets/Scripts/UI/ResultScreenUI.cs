// Assets/Scripts/UI/ResultScreenUI.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
            // —á‚Æ‚µ‚ÄAGameManager“™‚©‚çŒ‹‰Ê‚ğæ“¾‚µ‚Ä•\¦
            resultText.text = "Game Over !!";
        }

        public void OnRestartButtonClicked()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
