// Assets/Scripts/Effects/FakeExplosionEffect.cs
using UnityEngine;
using Bomb_Roulette.Audio;

namespace Bomb_Roulette.Effects
{
    public class FakeExplosionEffect : MonoBehaviour
    {
        public GameObject fakeExplosionPrefab;

        public void PlayFakeExplosion(Vector3 position)
        {
            Instantiate(fakeExplosionPrefab, position, Quaternion.identity);
            AudioManager.Instance.PlaySFX(1); // フェイク爆発用の効果音
        }
    }
}
