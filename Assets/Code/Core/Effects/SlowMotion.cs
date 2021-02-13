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
            LevelStateHandler.LevelState.OnBeforeEndMatch += OnGameEnd;
            LevelStateHandler.LevelState.OnStart += ResumeTime;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1f;
        }
        
        private void OnGameEnd(Belongs belongs)
        {
            Time.timeScale = _timeScale;
            StartCoroutine(WaitForSlowMoution(belongs));
        }
        private IEnumerator WaitForSlowMoution(Belongs winner)
        {
            while(true)
            {
                yield return new WaitForSeconds(_slowMotionTime);
                LevelStateHandler.LevelState.EndMatch(winner);
            }
        }
    }
}