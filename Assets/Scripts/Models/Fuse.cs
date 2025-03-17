// Assets/Scripts/Models/Fuse.cs
using UnityEngine;
using Bomb_Roulette.Effects;

namespace Bomb_Roulette.Models
{
    public class Fuse : MonoBehaviour
    {
        public bool isUsed = false;
        public float explosionProbability = 0.0f;

        public void Ignite()
        {
            if (!isUsed)
            {
                isUsed = true;
                FuseEffect fuseEffect = GetComponent<FuseEffect>();
                if (fuseEffect != null)
                {
                    fuseEffect.PlayFuseIgnition(transform.position);
                }
            }
        }
    }
}
