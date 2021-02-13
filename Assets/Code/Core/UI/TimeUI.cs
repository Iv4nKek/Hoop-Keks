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
        private void Start()
        {
            ResetTime();
           
            LevelStateHandler.LevelState.OnReset += ResetTime;
            LevelStateHandler.LevelState.OnReset += StopTime;
            LevelStateHandler.LevelState.OnStart += StartTime;
        }

        private void ResetTime()
        {
            rowTime = LevelStateHandler.LevelState.LevelTime;
        }
        private void StopTime()
        {
            rowTime = LevelStateHandler.LevelState.LevelTime;
            StopCoroutine(HandleTime());
        }

        private void StartTime()
        {
            StartCoroutine(HandleTime());
        }
        private void UpdateTimeText()
        {
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