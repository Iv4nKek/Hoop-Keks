using System;
using System.Collections.Generic;
using System.Drawing;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace Code.Core.UI
{
    public class PointsUI : MonoBehaviour
    {
        [SerializeField] private float _scaleTween;
        [SerializeField] private float _duration;
        [SerializeField] private Color _defaulColor;
        [SerializeField] private Color _goalColor;
        
        [SerializeField] private Transform _playerPointsTransform;
        [SerializeField] private Transform _botPointsTransform;
        [SerializeField] private GameObject _point;
        [SerializeField] private List<Image> _playerPoints = new List<Image>();
        [SerializeField] private List<Image> _botPoints = new List<Image>();

        private int _pointsCount;
        private LevelStateHandler _levelState;

        private void OnEnable()
        {
            
            
        }

        private void OnDisable()
        {
            LevelStateHandler.LevelState.OnGoal -= HandleGoal;
        }

        private void Start()
        {
            _levelState = LevelStateHandler.LevelState;
            _levelState.OnGoal += HandleGoal;
            _pointsCount = LevelStateHandler.LevelState.WinScore; 
            CreatePoints(_playerPointsTransform,_playerPoints);
            CreatePoints(_botPointsTransform,_botPoints);
        }

        private void HandleGoal(Belongs belongs)
        {
            if (belongs == Belongs.Player)
            {
                int score = _levelState.PlayerScore-1;
                if (score < _playerPoints.Count)
                {
                    Image point = _playerPoints[score];
                    TweenPoint(point);
                }
            }
            else
            {
                int score = _levelState.BotScore-1;
                if (score < _botPoints.Count)
                {
                    Image point = _botPoints[score];
                    TweenPoint(point);
                }
            }
        }
        private void CreatePoints(Transform transform,List<Image> pointsList)
        {
            for (int i = 0; i < _pointsCount; i++)
            {
                GameObject go = Instantiate(_point,transform);
                Image image = go.GetComponent<Image>();
                image.color = _defaulColor;
                pointsList.Add(image);
            }
        }

        private void TweenPoint(Image point)
        {
            point.transform.DOScale(point.transform.localScale*_scaleTween,_duration).SetLoops(2, LoopType.Yoyo);
            point.DOColor(_goalColor,_duration);
        }
        
    }
}