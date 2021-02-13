using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Code.Core.UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _winText;
        [SerializeField] private TMP_Text _loseText;
        [SerializeField] private Color _winColor;
        [SerializeField] private Color _loseColor;
        [SerializeField] private Color _defaultColor;
        
        [SerializeField] private Tournament _tournament;
        [SerializeField] private Image[] _trophiesParents = new Image[4];
        [SerializeField] private Image[] _trophies = new Image[4];
        [SerializeField] private Transform _menuUI;

        private GameStateHandler _gameStateHandler;

        private void Start()
        {
            _gameStateHandler = GameStateHandler.StateHandler;
            foreach (var trophey in _trophies)
            {
                trophey.color = _defaultColor;
            }

            LevelStateHandler.LevelState.OnEndMatch += UpdateUI;
        }

        

        private void UpdateUI(Belongs winner)
        {
            _menuUI.gameObject.SetActive(true);
            SetLabelText(winner == Belongs.Player);
            int stage = _gameStateHandler.State.Tournament.Stage;
            int trophyIndex = stage - 1;
            UpdateColors(trophyIndex);
            Color current = winner == Belongs.Player ? _winColor : _loseColor;
            TweenTrophy(trophyIndex,current);
        }

        private void SetLabelText(bool isWin)
        {
            _winText.gameObject.SetActive(isWin);
            _loseText.gameObject.SetActive(!isWin);
        }
        private void UpdateColors(int currentTrophy)
        {
            for (int i = 0; i < currentTrophy+1; i++)
            {
                _trophies[i].color = _winColor;
                _trophies[i].fillAmount = 1f;
            }

            if (currentTrophy < _trophies.Length-2)
            {
                for (int i = currentTrophy+1; i < _trophies.Length-1; i++)
                {
                    _trophies[i].color = _defaultColor;
                }
            }
        }

        private void TweenTrophy(int index, Color color)
        {
            
            Image parent = _trophiesParents[index];
            Image trophy = _trophies[index];
            trophy.color = color;
            parent.DORewind();
            parent.transform.DOScale(1.3f, 0.5f).SetLoops(2, LoopType.Yoyo);
            trophy.fillAmount = 0f;
            trophy.DORewind();
            trophy.DOFillAmount(1, 0.5f);

        }
    }
}