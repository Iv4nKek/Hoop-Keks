using System;
using System.Timers;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Code.Core.Inputs
{
    public class BotInput : JumpInput
    {
        private float currentTime;
        [SerializeField]private float targetTime = 1f;
        
        private void Start()
        {
       
        }
       

      

        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime > targetTime)
            {
                ProcessBotInput();
                currentTime = 0;
            }
        }


        private void ProcessBotInput()
        {
            Ball ball = LevelStateHandler.LevelState.Ball;
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