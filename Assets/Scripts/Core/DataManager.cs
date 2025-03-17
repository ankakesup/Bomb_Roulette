// Assets/Scripts/Core/DataManager.cs
using UnityEngine;

namespace Bomb_Roulette.Core
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;
        public int highScore = 0;

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

        public void SaveData()
        {
            // 例：PlayerPrefs を利用してデータを保存
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        public void LoadData()
        {
            if (PlayerPrefs.HasKey("HighScore"))
            {
                highScore = PlayerPrefs.GetInt("HighScore");
            }
        }
    }
}
