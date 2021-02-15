using Code.CentralBall;
using Code.States;
using UnityEngine;

namespace Code.Inputs
{
    public class BotInput : JumpInput
    {
        private float _currentTime;
        [SerializeField]private float _targetTime = 1f;
        
       
        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _targetTime)
            {
                ProcessBotInput();
                _currentTime = 0;
            }
        }

        //Deep neural network 
        private void ProcessBotInput()
        {
            Ball ball = LevelStateHandler.Instance.Ball;
            Vector2 position = ball.transform.position;
            Vector2 currentPosition = transform.position;
            Vector2 difference = position - currentPosition;
            if (difference.y > 0)
            {
                if (difference.x > 0)
                {
                    RightJump();
                }
                else
                {
                    LeftJump();
                }
            }
        }
    }
}