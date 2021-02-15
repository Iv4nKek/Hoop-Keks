using Code.States;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private float _duration;
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
            _levelStateHandler.OnStart += OnLevelStart;
            _playerScore.color = _defaulColor;
            _botScore.color = _defaulColor;
        }

        private void OnDisable()
        {
            _levelStateHandler.OnGoal -= HandleGoal;
            _levelStateHandler.OnFlexBit -= HandleGoal;
            _levelStateHandler.OnReset -= UpdateText;
            _levelStateHandler.OnStart -= OnLevelStart;
        }

        private void OnLevelStart()
        {
            _score.gameObject.SetActive(!_levelStateHandler.IsBonusLevel);

        }
        
     
        private void HandleGoal(PlayerType playerType)
        {
            
            UpdateText();
            if(playerType == PlayerType.Player)
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
            text.DOColor(_goalColor, _duration).SetLoops(2,LoopType.Yoyo);
        }
        private void TweenScale(RectTransform rectTransform)
        {
            rectTransform.DORewind();
            rectTransform.DOSizeDelta(rectTransform.sizeDelta*1.5f,_duration).SetLoops(2, LoopType.Yoyo);
            
        }
    }
}