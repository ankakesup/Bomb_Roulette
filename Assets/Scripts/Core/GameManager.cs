// Assets/Scripts/Core/GameManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bomb_Roulette.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            // 初期シーンとしてタイトル画面をロード
            LoadTitleScene();
        }

        public void LoadTitleScene()
        {
            // タイトル画面の呼び出し
            SceneManager.LoadScene("TitleScene");
        }

        public void StartGame()
        {
            TurnManager.Instance.ResetTurn();
            // ゲーム画面の呼び出し
            SceneManager.LoadScene("GameScene");
        }

        public void EndGame()
        {
            // リザルト画面の呼び出し
            SceneManager.LoadScene("ResultScene");
        }
    }
}
