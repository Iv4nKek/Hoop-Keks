using System;
using UnityEngine;

namespace Code.Core
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _areaCollider;
        [SerializeField] private CircleCollider2D _goalCollider;

        public CircleCollider2D AreaCollider => _areaCollider;

        public CircleCollider2D GoalCollider => _goalCollider;

        private void OnEnable()
        {
            LevelStateHandler.LevelState.Ball = this;
        }
    }
}