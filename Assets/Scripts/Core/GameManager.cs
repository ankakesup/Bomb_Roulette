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
            SceneManager.LoadScene("TitleScene");
        }

        public void StartGame()
        {
            // �Q�[���J�n�O�̏����������Ȃ�
            SceneManager.LoadScene("GameScene");
        }

        public void EndGame()
        {
            // �Q�[���I����A���U���g��ʂ�
            SceneManager.LoadScene("ResultScene");
        }
    }
}
