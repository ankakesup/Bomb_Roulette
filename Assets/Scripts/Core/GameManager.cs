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
            // �����V�[���Ƃ��ă^�C�g����ʂ����[�h
            LoadTitleScene();
        }

        public void LoadTitleScene()
        {
            // �^�C�g����ʂ̌Ăяo��
            SceneManager.LoadScene("TitleScene");
        }

        public void StartGame()
        {
            TurnManager.Instance.ResetTurn();
            // �Q�[����ʂ̌Ăяo��
            SceneManager.LoadScene("GameScene");
        }

        public void EndGame()
        {
            // ���U���g��ʂ̌Ăяo��
            SceneManager.LoadScene("ResultScene");
        }
    }
}
