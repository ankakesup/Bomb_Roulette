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
            RoundManager roundManager = FindObjectOfType<RoundManager>();
            roundManager.ResetRound();
            // �Q�[����ʂ̌Ăяo��
            SceneManager.LoadScene("GameScene");
            // �V�[�����ǂݍ��܂ꂽ��ɏ��������s
            SceneManager.sceneLoaded += OnSceneLoaded;
        }


        // �V�[�����ǂݍ��܂ꂽ��ɌĂ΂��R�[���o�b�N
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // �V�[�������[�h���ꂽ��� Fuse �𐶐�
            Fuse fuse = FindObjectOfType<Fuse>();
            if (fuse != null)
            {
                int numPlayers = TurnManager.Instance.GetNumPlayers();
                fuse.GenerateFuses(numPlayers + 1);
            }
            else
            {
                Debug.LogError("Fuse�I�u�W�F�N�g���V�[�����Ɍ�����܂���");
            }

            // �C�x���g���X�i�[�̉���
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void EndGame()
        {
            // ���U���g��ʂ̌Ăяo��
            SceneManager.LoadScene("ResultScene");
        }
    }
}
