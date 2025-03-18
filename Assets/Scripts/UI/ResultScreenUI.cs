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
            // 例として、GameManager等から結果を取得して表示
            resultText.text = "ゲームオーバー！\n〇〇が爆発しました。";
        }

        public void OnRestartButtonClicked()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
