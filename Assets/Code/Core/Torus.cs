using System;
using Code.Core.Inputs;
using UnityEngine;

namespace Code.Core
{
    public class Torus : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        
        [SerializeField] private float material;
        [SerializeField] private JumpInput _jumpInput;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private void OnEnable()
        {
            _jumpInput.OnLeftJump += JumpLeft;
            _jumpInput.OnRightJump += JumpRight;
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