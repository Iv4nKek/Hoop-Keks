using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Code.Core.UI
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timeText;

        private int rowTime;
        private Coroutine _coroutine;
        private void Start()
        {
            ResetTime();
           
            LevelStateHandler.Instance.OnReset += Reset;
            LevelStateHandler.Instance.OnStart += StartTime;
        }

        private void ResetTime()
        {
            rowTime = LevelStateHandler.Instance.LevelTime;
        }

        private void Reset()
        {
            rowTime = LevelStateHandler.Instance.LevelTime;
            StopTime();
            
        }
        private void StopTime()
        {
            StopCoroutine(_coroutine);
        }

        private void StartTime()
        {
            _coroutine = StartCoroutine(HandleTime());
        }
        private void UpdateTimeText()
        {
            if (rowTime <= 0)
            {
                LevelStateHandler.Instance.TimeExpired();
                StopTime();
                rowTime = Math.Abs(rowTime);
            }
                
            int seconds = rowTime % 60;
            int minutes = rowTime / 60;
            string secondText = seconds < 10 ? "0"+seconds : seconds.ToString();
            _timeText.text = $"{minutes}:{secondText}";
        }

        
        private IEnumerator HandleTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                rowTime--;
                UpdateTimeText();

            }
        }
    }
}