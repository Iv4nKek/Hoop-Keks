using System;
using Code.States;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private float _animationDuration;
        [SerializeField] private TMP_Text _winText;
        [SerializeField] private TMP_Text _loseText;
        [SerializeField] private Color _winColor;
        [SerializeField] private Color _loseColor;
        [SerializeField] private Color _defaultColor;
        
        
        [SerializeField] private Image[] _trophiesParents = new Image[4];
        [SerializeField] private Image[] _trophies = new Image[4];
        [SerializeField] private Transform _menuUI;

        [SerializeField] private Image _bonusLevel;

        private GameStateHandler _gameStateHandler;

        private void Start()
        {
            _gameStateHandler = GameStateHandler.Instance;
            foreach (var trophey in _trophies)
            {
                trophey.color = _defaultColor;
            }

            LevelStateHandler.Instance.OnEndMatch += UpdateUI;
        }

        private void OnDestroy()
        {
            LevelStateHandler.Instance.OnEndMatch -= UpdateUI;
        }


        private void UpdateUI(PlayerType winner)
        {
            _menuUI.gameObject.SetActive(true);
            SetLabelText(winner == PlayerType.Player);
            TweenBonusLevelImage();
            int trophiesWon = _gameStateHandler.State.TrophiesWon;
            UpdateColors(trophiesWon);
            Color current = winner == PlayerType.Player ? _winColor : _loseColor;
            if(trophiesWon != 0)
                TweenTrophy(trophiesWon,current);
        }

        private void TweenBonusLevelImage()
        {
            _bonusLevel.DOFillAmount(_gameStateHandler.State.BonusValue, _animationDuration*2f);
        }
        private void SetLabelText(bool isWin)
        {
            _winText.gameObject.SetActive(isWin);
            _loseText.gameObject.SetActive(!isWin);
        }

        private void UpdateWonTrophies(int trophiesWon)
        {
            for (int i = 0; i < trophiesWon-1; i++)
            {
                _trophies[i].color = _winColor;
                _trophies[i].fillAmount = 1f;
            }
        }
        private void UpdateIncomingTrophies(int trophiesWon)
        {
            for (int i = trophiesWon; i < _trophies.Length; i++)
            {
                _trophies[i].color = _defaultColor;
            }
        }
        private void UpdateColors(int trophiesWon)
        {
            if (trophiesWon > 0)
            {
                UpdateWonTrophies(trophiesWon);
            }

            if (trophiesWon < 4)
            {
                UpdateIncomingTrophies(trophiesWon);
            }
        }

        private void TweenTrophy(int trophiesWon, Color color)
        {
            
            Image parent = _trophiesParents[trophiesWon-1];
            Image trophy = _trophies[trophiesWon-1];
            trophy.color = color;
            parent.DORewind();
            parent.transform.DOScale(1.3f, _animationDuration).SetLoops(2, LoopType.Yoyo);
            trophy.fillAmount = 0f;
            trophy.DORewind();
            trophy.DOFillAmount(1, _animationDuration).SetLoops(1);

        }
    }
}