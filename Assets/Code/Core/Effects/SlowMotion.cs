using System.Collections;
using UnityEngine;

namespace Code.Core.Effects
{
    public class SlowMotion : MonoBehaviour
    {
        [SerializeField] private float _slowMotionTime = 1f;
        [SerializeField] private float _timeScale = 0.5f;
        
        private void Start()
        {
            LevelStateHandler.Instance.OnBeforeEndMatch += OnBeforeGameEnd;
            LevelStateHandler.Instance.OnStart += ResumeTime;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1f;
        }
        
        private void OnBeforeGameEnd(Belongs belongs)
        {
            Handheld.Vibrate();
            Time.timeScale = _timeScale;
            StartCoroutine(WaitForSlowMoution(belongs));
        }
        private IEnumerator WaitForSlowMoution(Belongs winner)
        {
            while(true)
            {
                yield return new WaitForSeconds(_slowMotionTime);
                LevelStateHandler.Instance.EndMatch(winner);
                break;
            }
        }
    }
}