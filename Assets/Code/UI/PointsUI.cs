using System.Collections.Generic;
using Code.States;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace Code.UI
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
        private bool _isCreated;

       
        private void OnDisable()
        {
            LevelStateHandler.Instance.OnGoal -= HandleGoal;
            _levelState.OnStart -= ResetPoints;
        }

        private void Start()
        {
            _levelState = LevelStateHandler.Instance;
            _pointsCount = _levelState.WinScore; 
            CreatePoints(_playerPointsTransform,_playerPoints);
            CreatePoints(_botPointsTransform,_botPoints);
           
            _levelState.OnGoal += HandleGoal;
            _levelState.OnStart += ResetPoints;
           
        }

        private void HandleGoal(PlayerType playerType)
        {
            if (playerType == PlayerType.Player)
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

        private void ResetPoints()
        {
            for (int i = 0; i < _pointsCount; i++)
            {
                Image image = _botPoints[i];
                image.color = _defaulColor;
            }
            for (int i = 0; i < _pointsCount; i++)
            {
                Image image = _playerPoints[i];
                image.color = _defaulColor;
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