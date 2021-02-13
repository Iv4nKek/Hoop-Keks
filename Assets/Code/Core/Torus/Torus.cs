using System;
using Code.Core.Inputs;
using UnityEngine;

namespace Code.Core
{
    public class Torus : MonoBehaviour
    {
        [SerializeField] private Belongs _belongs;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Vector2 _jumpVector;
        
        [SerializeField] private JumpInput _jumpInput;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private CircleCollider2D _ballCollider;
        [SerializeField] private CircleCollider2D _ballGoalCollider;

        
        private bool _goalLocked;
        private bool _controlLocked;
        

        private void Start()
        {
            UpdateBallColliders();
            LevelStateHandler.LevelState.OnBeforeEndMatch += LockControl;
            LevelStateHandler.LevelState.OnStart += UnlockControl;
            LevelStateHandler.LevelState.OnStart += UpdateBallColliders;
        }

        private void LockControl(Belongs belongs)
        {
            _controlLocked = true;
        }

        private void UnlockControl()
        {
            _controlLocked = false;
        }
        public void UpdateBallColliders()
        {
            Ball ball = LevelStateHandler.LevelState.Ball;
            Physics2D.IgnoreCollision(ball.AreaCollider, GetComponent<PolygonCollider2D>());
            Physics2D.IgnoreCollision(ball.GoalCollider, GetComponent<PolygonCollider2D>());
        }

        private void OnEnable()
        {
            _jumpInput.OnLeftJump += JumpLeft;
            _jumpInput.OnRightJump += JumpRight;
        }

        public void UnlockGoal()
        {
            _goalLocked = false;
        }

        public void HandleGoalIntersection()
        {
            if (!_goalLocked)
            {
                _goalLocked = true;
                LevelStateHandler.LevelState.AddPoint(_belongs);
            }
        }
        public void JumpRight()
        {
            if(_controlLocked)
                return;
            
            Vector2 force = _jumpVector*_jumpForce;
            force = new Vector2(force.x, force.y + 10);
            _rigidbody2D.velocity = new Vector2();
            _rigidbody2D.AddForce(force);
        }

        public void JumpLeft()
        {
            if(_controlLocked)
                return;
            
            _rigidbody2D.velocity = new Vector2();
            _rigidbody2D.AddForce(new Vector2(-_jumpVector.x,_jumpVector.y)*_jumpForce);
        }

        private void OnDisable()
        {
            _jumpInput.OnLeftJump -= JumpLeft;
            _jumpInput.OnRightJump -= JumpRight;
        }

       
    }
}