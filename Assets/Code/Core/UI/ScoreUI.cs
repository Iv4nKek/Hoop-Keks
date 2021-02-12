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

       
      

        private LevelStateHandler _levelStateHandler;
        private Tween _tween;

        private void Start()
        {
            _levelStateHandler = LevelStateHandler.LevelState;
            _levelStateHandler.OnGoal += HandleGoal;

            _playerScore.color = _defaulColor;
            _botScore.color = _defaulColor;

            SetupTween();
        }

        
        private void SetupTween()
        {
            _tween = _playerScore.rectTransform.DOSizeDelta(_playerScore.rectTransform.sizeDelta*1.5f,duration);
            _tween.SetLoops(2, LoopType.Yoyo);
            _tween.SetAutoKill(false);
            _tween.Pause();
        }

        private void HandleGoal(Belongs belongs)
        {
            if(belongs == Belongs.Player)
                UpdateScore(_playerScore,_levelStateHandler.PlayerScore);
            else
                UpdateScore(_botScore,_levelStateHandler.BotScore);
        }

        private void UpdateScore(TMP_Text text, int score)
        {
            text.text = score.ToString();
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