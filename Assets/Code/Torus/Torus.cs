using Code.CentralBall;
using Code.Eco;
using Code.Eco.SkinShop;
using Code.Inputs;
using Code.States;
using UnityEngine;

namespace Code.Torus
{
    public class Torus : MonoBehaviour
    {
        [SerializeField] private PlayerType _playerType;
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
      
        private void OnDestroy()
        {
            _jumpInput.OnLeftJump -= JumpLeft;
            _jumpInput.OnRightJump -= JumpRight;
            LevelStateHandler.Instance.OnBeforeEndMatch -= LockControl;
            LevelStateHandler.Instance.OnStart -= UnlockControl;
            LevelStateHandler.Instance.OnStart -= UpdateBallColliders;
            LevelStateHandler.Instance.OnStart -= UpdateSkin;
            
        }
        private void UpdateSkin()
        {
            Skin skin;
            if (_playerType == PlayerType.Player)
            {
                skin = SkinHandler.Instance.GetPlayerSkin();
            }
            else
            {
                skin = SkinHandler.Instance.GetBotSkin();
            }

            _renderer.material = skin.Material;


        }
        private void LockControl(PlayerType playerType)
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
                LevelStateHandler.Instance.AddPoint(_playerType);
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