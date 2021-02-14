using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code.Core.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private Color _defaulColor;
        [SerializeField] private Color _goalColor;
        
        [SerializeField] private TMP_Text _playerScore;
        [SerializeField] private TMP_Text _botScore;
        [SerializeField] private Transform _score;
        

        private LevelStateHandler _levelStateHandler;

        private void Start()
        {
            _levelStateHandler = LevelStateHandler.Instance;
            _levelStateHandler.OnGoal += HandleGoal;
            _levelStateHandler.OnFlexBit += HandleGoal;
            _levelStateHandler.OnReset += UpdateText;
            _levelStateHandler.OnStart += OnStart;
            _playerScore.color = _defaulColor;
            _botScore.color = _defaulColor;

        }

        private void OnStart()
        {
            _score.gameObject.SetActive(!_levelStateHandler.IsBonusLevel);

        }
        
     
        private void HandleGoal(Belongs belongs)
        {
            
            UpdateText();
            if(belongs == Belongs.Player)
                UpdateScore(_playerScore,_levelStateHandler.PlayerScore);
            else
                UpdateScore(_botScore,_levelStateHandler.BotScore);
        }

        private void UpdateText()
        {
         
            _playerScore.text = _levelStateHandler.PlayerScore.ToString();
            _botScore.text = _levelStateHandler.BotScore.ToString();
        }
        private void UpdateScore(TMP_Text text, int score)
        {
            TweenColor(text);
            TweenScale(text.rectTransform);

        }

        private void TweenColor(TMP_Text text)
        {
            text.DORewind();
            text.DOColor(_goalColor, duration).SetLoops(2,LoopType.Yoyo);
        }
        private void TweenScale(RectTransform rectTransform)
        {
            rectTransform.DORewind();
            rectTransform.DOSizeDelta(rectTransform.sizeDelta*1.5f,duration).SetLoops(2, LoopType.Yoyo);
            
        }
    }
}