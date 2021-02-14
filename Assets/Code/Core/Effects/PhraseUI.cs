using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Core.Effects
{
    public class PhraseUI : MonoBehaviour
    {
       
        [SerializeField] private List<Color> _textColors;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private DOTweenAnimation _animation;
        [SerializeField] private PhraseHandler _phraseHandler;

        [SerializeField] private Transform _leftTransform;
        [SerializeField] private Transform _rightTransform;


        private bool isLeftSide;

        private void Start()
        {
           LevelStateHandler.Instance.OnGoal+=OnGoal;
           LevelStateHandler.Instance.OnReset+=DisableText;
        }

       

        private void DisableText()
        {
            _text.text = "";
        }
        
        private void OnGoal(Belongs belongs)
        {
            if (belongs == Belongs.Player)
            {
                ShowPhrase();
            }
        }

       

        private void ShowPhrase()
        {
            if (isLeftSide)
            {
                _text.transform.position = _leftTransform.position;
                _text.transform.rotation = _leftTransform.rotation;
            }
            else
            {
                _text.transform.position = _rightTransform.position;
                _text.transform.rotation = _rightTransform.rotation;
            }

            isLeftSide = !isLeftSide;
            _text.gameObject.SetActive(true);
            _text.text = _phraseHandler.GetPhrase();
            _text.color = _textColors[Random.Range(0, _textColors.Count)];
            _animation.DORestart();
        }
    }
}