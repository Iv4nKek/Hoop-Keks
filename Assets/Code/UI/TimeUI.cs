using System;
using System.Collections;
using Code.States;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timeText;

        private int _rowTime;
        private Coroutine _coroutine;

        private void Start()
        {
            ResetTime();
            LevelStateHandler.Instance.OnReset += Reset;
            LevelStateHandler.Instance.OnStart += StartTime;
        }

        private void OnDisable()
        {
            LevelStateHandler.Instance.OnReset -= Reset;
            LevelStateHandler.Instance.OnStart -= StartTime;
        }

        private void ResetTime()
        {
            _rowTime = LevelStateHandler.Instance.LevelTime;
        }

        private void Reset()
        {
            _rowTime = LevelStateHandler.Instance.LevelTime;
            UpdateTimeText();
            StopTime();
        }

        private void StopTime()
        {
            StopCoroutine(_coroutine);
        }

        private void StartTime()
        {
            UpdateTimeText();
            _coroutine = StartCoroutine(HandleTime());
           
        }

        private void UpdateTimeText()
        {
            if (_rowTime <= 0)
            {
                LevelStateHandler.Instance.TimeExpired();
                StopTime();
                _rowTime = Math.Abs(_rowTime);
            }

            int seconds = _rowTime % 60;
            int minutes = _rowTime / 60;
            string secondText = seconds < 10 ? "0" + seconds : seconds.ToString();
            _timeText.text = $"{minutes}:{secondText}";
        }

        private IEnumerator HandleTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _rowTime--;
                UpdateTimeText();
            }
        }
    }
}