using System;
using System.Xml;
using UnityEngine;

namespace Code.Core.Inputs
{
    public class PlayerInput: JumpInput
    {
        private void Update()
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