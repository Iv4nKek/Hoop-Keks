using System.Collections.Generic;
using Code.States;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.UI.Phrases
{
    public class PhraseUI : MonoBehaviour
    {
       
        [SerializeField] private List<Color> _textColors;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private DOTweenAnimation _animation;
        [SerializeField] private PhraseHandler _phraseHandler;

        [SerializeField] private Transform _leftTransform;
        [SerializeField] private Transform _rightTransform;


        private bool _isLeftSide;

        private void Start()
        {
           LevelStateHandler.Instance.OnGoal+=OnGoal;
           LevelStateHandler.Instance.OnFlexBit+=OnGoal;
           LevelStateHandler.Instance.OnReset+=DisableText;
        }

        private void OnDestroy()
        {
            LevelStateHandler.Instance.OnGoal -= OnGoal;
            LevelStateHandler.Instance.OnFlexBit -= OnGoal;
            LevelStateHandler.Instance.OnReset -= DisableText;
        }

        private void DisableText()
        {
            _text.text = "";
        }
        
        private void OnGoal(PlayerType playerType)
        {
            if (playerType == PlayerType.Player)
            {
                ShowPhrase();
            }
        }

       

        private void ShowPhrase()
        {
            if (_isLeftSide)
            {
                _text.transform.position = _leftTransform.position;
                _text.transform.rotation = _leftTransform.rotation;
            }
            else
            {
                _text.transform.position = _rightTransform.position;
                _text.transform.rotation = _rightTransform.rotation;
            }

            _isLeftSide = !_isLeftSide;
            _text.gameObject.SetActive(true);
            _text.text = _phraseHandler.GetPhrase();
            _text.color = _textColors[Random.Range(0, _textColors.Count)];
            _animation.DORestart();
        }
    }
}