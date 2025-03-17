// Assets/Scripts/Effects/FuseEffect.cs
using UnityEngine;
using Bomb_Roulette.Audio;

namespace Bomb_Roulette.Effects
{
    public class FuseEffect : MonoBehaviour
    {
        public GameObject fuseIgnitionPrefab;

        public void PlayFuseIgnition(Vector3 position)
        {
            Instantiate(fuseIgnitionPrefab, position, Quaternion.identity);
            AudioManager.Instance.PlaySFX(2); // “±‰Îü“_‰Î‚ÌŒø‰Ê‰¹
        }
    }
}
