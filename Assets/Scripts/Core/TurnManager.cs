// Assets/Scripts/Core/TurnManager.cs
using UnityEngine;
using System.Collections.Generic;
using Bomb_Roulette.Models;
using Bomb_Roulette.UI;

namespace Bomb_Roulette.Core
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance;
        private int currentTurn = 0; // 現在のターン(Nターン目に対して，N-1の値を取る)
        private int numPlayers = 0; // プレイヤーの人数の管理
        private int explodedPlayer = -1; // 爆発したプレイヤーの番号（初期値-1）

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        public void ResetTurn()
        {
            currentTurn = 0;
            explodedPlayer = -1;
        }



        public void SetNumPlayers(int numPlayersTemp) // TitleScreenUI からプレイヤーの人数を取得する関数
        {
            numPlayers = numPlayersTemp;

        }

        public int GetNumPlayers() // numPlayers の値を返す関数
        {
            return numPlayers;
        }

        public bool CheckForExplosion()
        {
            RoundManager roundManager = FindObjectOfType<RoundManager>();
            bool isSuddenDeath = roundManager.IsSuddenDeath();
            float explosionProbability;     //爆破確率
            float fakeExplosionProbability = 0.1f; // 10% の確率でフェイク爆発

            if (isSuddenDeath)
            {
                explosionProbability = 1f / (numPlayers - currentTurn);
            }
            else
            {
                explosionProbability = 1f / (numPlayers - currentTurn + 1);
            }

            Debug.Log($"Player {currentTurn + 1} の爆発確率: {explosionProbability * 100}%");

            if (Random.value < explosionProbability) // 0.0 〜 1.0 の範囲でランダム値を生成
            {
                BombExploded();
                return true; // 爆発したことを示す
            }
            else if (Random.value < fakeExplosionProbability)
            {
                Debug.Log($"Player {currentTurn + 1} はfake爆破を起こした");
                //フェイク爆破の演出を入れる↓

                return false;
            }

                return false;
        }


        public void NextTurn() // 次のターンにする関数
        {
            //-------後に導火線を決定したタイミングで実行するように変更する--------------------
            // 現在のプレイヤーが爆発するかチェック
            if (CheckForExplosion())
            {
                return; // 爆発したらゲーム終了するので、次のターンへ進まない
            }
            //--------------------------------------------------------------------------

            currentTurn = currentTurn + 1;
            if (currentTurn == numPlayers) // 全員のターンが終わったらラウンドを更新する
            {
                // 次のaまでのコードで RoundManager の NextRound関数 の呼び出しを行う
                RoundManager roundManager = FindObjectOfType<RoundManager>();
                roundManager.NextRound();
                // a
                currentTurn = 0; // ラウンドのはじめにcurrentTurnを0にリセットする
            }
            UpdateTurnUI(); // UIの更新
            Debug.Log(numPlayers);
        }

        void UpdateTurnUI()
        {
            Debug.Log("Turn: Player" + (currentTurn + 1));

            if (GameUI.Instance != null)
            {
                GameUI.Instance.UpdateTurnDisplay(currentTurn + 1);
            }
            else
            {
                Debug.LogError("GameUI のインスタンスが見つかりません。シーンに配置されているか確認してください。");
            }
        }

        public void BombExploded()
        {
            explodedPlayer = currentTurn; // 爆発したプレイヤーを記録
            GameManager.Instance.EndGame(); // 結果画面へ移行
        }

        public int GetExplodedPlayer()
        {
            return explodedPlayer;
        }
    }
}
