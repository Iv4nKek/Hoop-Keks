using System.Collections;
using Code.States;
using UnityEngine;

namespace Code.Effects
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

        private void OnDestroy()
        {
            LevelStateHandler.Instance.OnBeforeEndMatch -= OnBeforeGameEnd;
            LevelStateHandler.Instance.OnStart -= ResumeTime;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1f;
        }
        
        private void OnBeforeGameEnd(PlayerType playerType)
        {
            Handheld.Vibrate();
            Time.timeScale = _timeScale;
            StartCoroutine(WaitForSlowMoution(playerType));
        }
        private IEnumerator WaitForSlowMoution(PlayerType winner)
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