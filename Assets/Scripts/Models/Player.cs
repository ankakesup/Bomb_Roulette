// Assets/Scripts/Models/Player.cs
namespace Bomb_Roulette.Models
{
    public class Player
    {
        public string playerName;
        public int turnNumber;
        public bool isAlive;

        public Player(string name, int turn)
        {
            playerName = name;
            turnNumber = turn;
            isAlive = true;
        }

        public void Explode()
        {
            isAlive = false;
            // 爆発時の処理（エフェクト呼び出しなど）
        }
    }
}
