// Assets/Scripts/Models/Bomb.cs
using UnityEngine;
using Bomb_Roulette.Effects;
using UnityEngine.UI;
using System.Collections;
using Bomb_Roulette.Audio;

namespace Bomb_Roulette.Models
{
    public class Bomb : MonoBehaviour
    {
        // 画像のスプライト（インスペクタから設定）
        public Sprite normalBombSprite; // 通常の爆弾
        public Sprite fakeExplosionSprite; // フェイク爆発
        public Sprite realExplosionSprite; // 本物の爆発
        
        private Image bombImage;
        private RectTransform bombRectTransform;

        void Start()
        {
            // このゲームオブジェクトにアタッチされているImageコンポーネントを取得
            bombImage = GetComponent<Image>();
            bombRectTransform = GetComponent<RectTransform>();

            // 初期状態で通常の爆弾画像を設定
            SetNormalBomb();

        }

        // 通常の爆弾画像を設定するメソッド
        public void SetNormalBomb()
        {
            bombImage.sprite = normalBombSprite;
        }

        // フェイク爆発画像を設定するメソッド
        public void SetFakeExplosion()
        {
            bombImage.sprite = fakeExplosionSprite;

            // 0.5秒後に通常の爆弾画像に戻す
            StartCoroutine(ReturnToNormalBomb(0.5f));  // 0.5秒後に戻す
        }

        // 一定時間後に通常の爆弾画像に戻すCoroutine
        private IEnumerator ReturnToNormalBomb(float delay)
        {
            yield return StartCoroutine(ScaleUpBomb(0.5f)); // フェイク爆発の間に画像を拡大
            yield return new WaitForSeconds(delay);  // 指定した秒数だけ待機
            yield return StartCoroutine(ScaleDownBomb(0.5f)); // フェイク爆発の間に画像を拡大
            SetNormalBomb();  // 通常の爆弾画像に戻す
        }

        // フェイク爆発画像を設定し、次に本物の爆発画像に変えるCoroutine
        public IEnumerator TriggerFakeExplosionThenReal()
        {
            // コルーチンで順番に処理
            yield return StartCoroutine(FakeExplosionThenRealExplosion()); // FakeExplosionThenRealExplosion を実行して、その完了を待つ
        }
        // フェイク爆発から本物の爆発に変える処理
        private IEnumerator FakeExplosionThenRealExplosion()
        {
            // フェイク爆発画像に変更
            bombImage.sprite = fakeExplosionSprite;

            yield return StartCoroutine(ScaleUpBomb(0.5f)); // フェイク爆発の間に画像を拡大

            // フェイク爆発を一定時間表示
            yield return new WaitForSeconds(0.5f); // 0.5秒間待機

            // 本物の爆発画像に変更
            bombImage.sprite = realExplosionSprite;

            // 爆発音を出す
            AudioManager.Instance.PlaySFX(0);

            // フェイク爆発を一定時間表示
            yield return new WaitForSeconds(0.5f); // 0.5秒間待機

        }

        // 爆弾画像を拡大するコルーチン
        private IEnumerator ScaleUpBomb(float duration)
        {
            Vector3 originalScale = bombRectTransform.localScale; // 元のサイズ
            Vector3 targetScale = originalScale * 2f; // 目標のサイズ（2倍）

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                bombRectTransform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            bombRectTransform.localScale = targetScale; // 最終的に目標サイズに設定
        }


        // 画像を元のサイズに戻すCoroutine
        private IEnumerator ScaleDownBomb(float duration)
        {
            Vector3 originalScale = bombRectTransform.localScale; // 現在のサイズ
            Vector3 targetScale = originalScale / 2f; // 元のサイズに戻す（2倍に拡大したため、半分に戻す）

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                bombRectTransform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            bombRectTransform.localScale = targetScale; // 最終的に元のサイズに戻す
        }


        public bool isExploded = false;

        public void Explode()
        {
            isExploded = true;
            // 爆発エフェクトの再生
            ExplosionEffect explosionEffect = GetComponent<ExplosionEffect>();
            if (explosionEffect != null)
            {
                explosionEffect.PlayExplosion(transform.position);
            }
        }
    }
}
