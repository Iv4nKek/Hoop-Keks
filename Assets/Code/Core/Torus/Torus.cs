using System;
using Code.Core.Inputs;
using Code.Eco;
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
        [SerializeField] private MeshRenderer _renderer;

        
        private bool _goalLocked;
        private bool _controlLocked;
        

        private void Start()
        {
            
            _jumpInput.OnLeftJump += JumpLeft;
            _jumpInput.OnRightJump += JumpRight;
            LevelStateHandler.Instance.OnBeforeEndMatch += LockControl;
            LevelStateHandler.Instance.OnStart += UnlockControl;
            LevelStateHandler.Instance.OnStart += UpdateBallColliders;
            LevelStateHandler.Instance.OnStart += UpdateSkin;
            UpdateBallColliders();
            UpdateSkin();
        }
      
        /*private void OnDestroy()
        {
            Debug.Log("d");
            _jumpInput.OnLeftJump -= JumpLeft;
            _jumpInput.OnRightJump -= JumpRight;
            LevelStateHandler.Instance.OnBeforeEndMatch -= LockControl;
            LevelStateHandler.Instance.OnStart -= UnlockControl;
            LevelStateHandler.Instance.OnStart -= UpdateBallColliders;
            LevelStateHandler.Instance.OnStart -= UpdateSkin;
            
        }*/
        private void UpdateSkin()
        {
            Skin skin;
            if (_belongs == Belongs.Player)
            {
                skin = SkinHandler.Instance.GetPlayerSkin();
            }
            else
            {
                skin = SkinHandler.Instance.GetBotSkin();
            }

            _renderer.material = skin.Material;


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
            Ball ball = LevelStateHandler.Instance.Ball;
            Physics2D.IgnoreCollision(ball.AreaCollider, GetComponent<PolygonCollider2D>());
            Physics2D.IgnoreCollision(ball.GoalCollider, GetComponent<PolygonCollider2D>());
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
                LevelStateHandler.Instance.AddPoint(_belongs);
            }
        }
        private void JumpRight()
        {
            if(_controlLocked)
                return;
            
            Vector2 force = _jumpVector*_jumpForce;
            force = new Vector2(force.x, force.y + 10);
            _rigidbody2D.velocity = new Vector2();
            _rigidbody2D.AddForce(force);
        }

        private void JumpLeft()
        {
            if(_controlLocked)
                return;
            
            _rigidbody2D.velocity = new Vector2();
            _rigidbody2D.AddForce(new Vector2(-_jumpVector.x,_jumpVector.y)*_jumpForce);
        }

      

       
    }
}