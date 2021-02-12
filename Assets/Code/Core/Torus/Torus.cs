using System;
using Code.Core.Inputs;
using UnityEngine;

namespace Code.Core
{
    public class Torus : MonoBehaviour
    {
        [SerializeField] private Belongs belongs;
        [SerializeField] private float jumpForce;
        
        [SerializeField] private JumpInput _jumpInput;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private PolygonCollider2D _torusCollider;
        [SerializeField] private CircleCollider2D _ballCollider;
        [SerializeField] private CircleCollider2D _ballGoalCollider;
        [SerializeField] private BoxCollider2D _torusGoalCollider2D;
        
        private bool _goalLocked;

        private void Awake()
        {
            Physics2D.IgnoreCollision(_ballCollider, GetComponent<PolygonCollider2D>());
            Physics2D.IgnoreCollision(_ballGoalCollider, GetComponent<PolygonCollider2D>());
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
                LevelStateHandler.LevelState.AddPoint(belongs);
            }
        }
        public void JumpRight()
        {
            Vector2 force = new Vector2(1f,1f)*jumpForce;
            force = new Vector2(force.x, force.y + 10);
            _rigidbody2D.velocity = new Vector2();
            _rigidbody2D.AddForce(force);
        }

        public void JumpLeft()
        {
            _rigidbody2D.velocity = new Vector2();
            _rigidbody2D.AddForce(new Vector2(-1f,1f)*jumpForce);
        }

        private void OnDisable()
        {
            _jumpInput.OnLeftJump -= JumpLeft;
            _jumpInput.OnRightJump -= JumpRight;
        }

       
    }
}