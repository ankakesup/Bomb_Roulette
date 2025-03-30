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
        // �摜�̃X�v���C�g�i�C���X�y�N�^����ݒ�j
        public Sprite normalBombSprite; // �ʏ�̔��e
        public Sprite fakeExplosionSprite; // �t�F�C�N����
        public Sprite realExplosionSprite; // �{���̔���
        
        private Image bombImage;
        private RectTransform bombRectTransform;

        void Start()
        {
            // ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���Image�R���|�[�l���g���擾
            bombImage = GetComponent<Image>();
            bombRectTransform = GetComponent<RectTransform>();

            // ������ԂŒʏ�̔��e�摜��ݒ�
            SetNormalBomb();

        }

        // �ʏ�̔��e�摜��ݒ肷�郁�\�b�h
        public void SetNormalBomb()
        {
            bombImage.sprite = normalBombSprite;
        }

        // �t�F�C�N�����摜��ݒ肷�郁�\�b�h
        public void SetFakeExplosion()
        {
            bombImage.sprite = fakeExplosionSprite;

            // 0.5�b��ɒʏ�̔��e�摜�ɖ߂�
            StartCoroutine(ReturnToNormalBomb(0.5f));  // 0.5�b��ɖ߂�
        }

        // ��莞�Ԍ�ɒʏ�̔��e�摜�ɖ߂�Coroutine
        private IEnumerator ReturnToNormalBomb(float delay)
        {
            yield return StartCoroutine(ScaleUpBomb(0.5f)); // �t�F�C�N�����̊Ԃɉ摜���g��
            yield return new WaitForSeconds(delay);  // �w�肵���b�������ҋ@
            yield return StartCoroutine(ScaleDownBomb(0.5f)); // �t�F�C�N�����̊Ԃɉ摜���g��
            SetNormalBomb();  // �ʏ�̔��e�摜�ɖ߂�
        }

        // �t�F�C�N�����摜��ݒ肵�A���ɖ{���̔����摜�ɕς���Coroutine
        public IEnumerator TriggerFakeExplosionThenReal()
        {
            // �R���[�`���ŏ��Ԃɏ���
            yield return StartCoroutine(FakeExplosionThenRealExplosion()); // FakeExplosionThenRealExplosion �����s���āA���̊�����҂�
        }
        // �t�F�C�N��������{���̔����ɕς��鏈��
        private IEnumerator FakeExplosionThenRealExplosion()
        {
            // �t�F�C�N�����摜�ɕύX
            bombImage.sprite = fakeExplosionSprite;

            yield return StartCoroutine(ScaleUpBomb(0.5f)); // �t�F�C�N�����̊Ԃɉ摜���g��

            // �t�F�C�N��������莞�ԕ\��
            yield return new WaitForSeconds(0.5f); // 0.5�b�ԑҋ@

            // �{���̔����摜�ɕύX
            bombImage.sprite = realExplosionSprite;

            // ���������o��
            AudioManager.Instance.PlaySFX(0);

            // �t�F�C�N��������莞�ԕ\��
            yield return new WaitForSeconds(0.5f); // 0.5�b�ԑҋ@

        }

        // ���e�摜���g�傷��R���[�`��
        private IEnumerator ScaleUpBomb(float duration)
        {
            Vector3 originalScale = bombRectTransform.localScale; // ���̃T�C�Y
            Vector3 targetScale = originalScale * 2f; // �ڕW�̃T�C�Y�i2�{�j

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                bombRectTransform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            bombRectTransform.localScale = targetScale; // �ŏI�I�ɖڕW�T�C�Y�ɐݒ�
        }


        // �摜�����̃T�C�Y�ɖ߂�Coroutine
        private IEnumerator ScaleDownBomb(float duration)
        {
            Vector3 originalScale = bombRectTransform.localScale; // ���݂̃T�C�Y
            Vector3 targetScale = originalScale / 2f; // ���̃T�C�Y�ɖ߂��i2�{�Ɋg�債�����߁A�����ɖ߂��j

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                bombRectTransform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            bombRectTransform.localScale = targetScale; // �ŏI�I�Ɍ��̃T�C�Y�ɖ߂�
        }


        public bool isExploded = false;

        public void Explode()
        {
            isExploded = true;
            // �����G�t�F�N�g�̍Đ�
            ExplosionEffect explosionEffect = GetComponent<ExplosionEffect>();
            if (explosionEffect != null)
            {
                explosionEffect.PlayExplosion(transform.position);
            }
        }
    }
}
