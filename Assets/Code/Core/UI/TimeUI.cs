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
            rowTime = LevelStateHandler.LevelState.LevelTime;
            StartCoroutine(HandleTime());
        }

        private void UpdateTimeText()
        {
            int _seconds = rowTime % 60;
            int _minutes = rowTime / 60;
            string secondText = _seconds < 10 ? $"0{_seconds}" : _seconds.ToString();
            _timeText.text = $"{_minutes}:{secondText}";
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