using System;
using System.Collections;
using Code.States;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Code.UI
{
    public class BonusScoreUI : MonoBehaviour
    {
        [SerializeField] private float _scalePower;
        [SerializeField] private Color[] _textColors;
        [SerializeField] private float _shakePower;
        [SerializeField] private int _vibrations;
        [SerializeField] private Transform _camera;
        [SerializeField] private float _timeDelay;
        [SerializeField] private float _bitDelay;
        [SerializeField] private TMP_Text _playerScore;
        [SerializeField] private float _duration;
        [SerializeField] private VideoPlayer _player;
        [SerializeField] private Transform _score;
        [SerializeField] private Image _ricardoImage;

        private Coroutine _flex;

        private void Start()
        {
            LevelStateHandler.Instance.OnGoal += OnGoal;
            LevelStateHandler.Instance.OnStart += OnGameStart;
            LevelStateHandler.Instance.OnEndMatch += Pause;
        }

        private void OnDestroy()
        {
            LevelStateHandler.Instance.OnGoal -= OnGoal;
            LevelStateHandler.Instance.OnStart -= OnGameStart;
            LevelStateHandler.Instance.OnEndMatch -= Pause;
        }

        private void Pause(PlayerType winner)
        {
            _player.Stop();
            if(_flex != null)
                StopCoroutine(_flex);
        }
        private void OnGameStart()
        {
            bool isBonus = LevelStateHandler.Instance.IsBonusLevel;
            _score.gameObject.SetActive(isBonus);
            if (isBonus)
            {
                _player.Play();
                UpdateText();
                _flex=StartCoroutine(RicardoDance());
            }
            
        }
        private void OnGoal(PlayerType playerType)
        {
            UpdateText();
            TweenScale(_playerScore.rectTransform);
        }

        

        private void TweenScale(RectTransform rectTransform)
        {
            rectTransform.DORewind();
            rectTransform.DOSizeDelta(rectTransform.sizeDelta * 1.5f, _duration).SetLoops(2, LoopType.Yoyo);

        }

        private void UpdateText()
        {
            _playerScore.text = LevelStateHandler.Instance.PlayerScore.ToString();
        }

        IEnumerator RicardoDance()
        {
            int index = 0;
            yield return new WaitForSeconds(_timeDelay);
            while (true)
            {
                yield return new WaitForSeconds(_bitDelay);
                if (index >= _textColors.Length)
                {
                    index = 0;
                }

                
                

                if (_textColors.Length != 0)
                {
                    _playerScore.color = _textColors[index];
                    _ricardoImage.color = _textColors[index++];
                }
                UpdateText();
                ShakeCamera();
                TweenScore();
                LevelStateHandler.Instance.MakeFlexBit();
            }
        }

        private void TweenScore()
        {
            _ricardoImage.rectTransform.localScale  = new Vector3(1f,1f,1f);
            _ricardoImage.rectTransform.DOScale(_score.localScale.x * _scalePower, _duration);

        }
        private void ShakeCamera()
        {
            _camera.DORewind();
            _camera.DOKill();
            _camera.DOShakePosition(_duration,new Vector3(1,1,0)*_shakePower,_vibrations);
        }
    }
}