using System;
using System.Xml;
using UnityEngine;

namespace Code.Core.Inputs
{
    public class PlayerInput: JumpInput
    {
        [SerializeField]private bool _isMobile;
        private void Update()
        {
            if (_isMobile)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.mousePosition.x < Screen.width / 2f)
                    {
                        LeftJump();
                    }
                    else
                    {
                        RightJump();
                    }
                    
                   
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    LeftJump();
                }
                if (Input.GetMouseButtonDown(1))
                {
                    RightJump();
                }
            }
           
        }
    }
}