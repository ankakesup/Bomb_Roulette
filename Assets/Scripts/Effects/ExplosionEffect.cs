// Assets/Scripts/Effects/ExplosionEffect.cs
using UnityEngine;
using Bomb_Roulette.Audio;

namespace Bomb_Roulette.Effects
{
    public class ExplosionEffect : MonoBehaviour
    {
        public GameObject explosionPrefab;

        public void PlayExplosion(Vector3 position)
        {
            Instantiate(explosionPrefab, position, Quaternion.identity);
            AudioManager.Instance.PlaySFX(0); // �������i�C���f�b�N�X0��SFX�j
        }
    }
}