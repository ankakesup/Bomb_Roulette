// Assets/Scripts/Core/GameManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using Bomb_Roulette.Models;


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
            RoundManager roundManager = FindObjectOfType<RoundManager>();
            roundManager.ResetRound();
            // ゲーム画面の呼び出し
            SceneManager.LoadScene("GameScene");
            // シーンが読み込まれた後に処理を実行
            SceneManager.sceneLoaded += OnSceneLoaded;
        }


        // シーンが読み込まれた後に呼ばれるコールバック
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // シーンがロードされた後に Fuse を生成
            Fuse fuse = FindObjectOfType<Fuse>();
            if (fuse != null)
            {
                int numPlayers = TurnManager.Instance.GetNumPlayers();
                fuse.GenerateFuses(numPlayers + 1);
            }
            else
            {
                Debug.LogError("Fuseオブジェクトがシーン内に見つかりません");
            }

            // イベントリスナーの解除
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void EndGame()
        {
            // リザルト画面の呼び出し
            SceneManager.LoadScene("ResultScene");
        }
    }
}
