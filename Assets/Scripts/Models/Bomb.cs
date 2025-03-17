// Assets/Scripts/Models/Bomb.cs
using UnityEngine;
using Bomb_Roulette.Effects;

namespace Bomb_Roulette.Models
{
    public class Bomb : MonoBehaviour
    {
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
