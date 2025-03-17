// Assets/Scripts/Utilities/Timer.cs
using UnityEngine;
using System.Collections;

namespace Bomb_Roulette.Utilities
{
    public class Timer : MonoBehaviour
    {
        public float duration;
        public System.Action onTimerEnd;

        public void StartTimer(float time)
        {
            duration = time;
            StartCoroutine(TimerCoroutine());
        }

        IEnumerator TimerCoroutine()
        {
            while (duration > 0)
            {
                duration -= Time.deltaTime;
                yield return null;
            }
            onTimerEnd?.Invoke();
        }
    }
}
