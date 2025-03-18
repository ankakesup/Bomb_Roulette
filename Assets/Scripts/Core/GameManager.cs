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
            SceneManager.LoadScene("TitleScene");
        }

        public void StartGame()
        {
            // ゲーム開始前の初期化処理など
            SceneManager.LoadScene("GameScene");
        }

        public void EndGame()
        {
            // ゲーム終了後、リザルト画面へ
            SceneManager.LoadScene("ResultScene");
        }
    }
}
