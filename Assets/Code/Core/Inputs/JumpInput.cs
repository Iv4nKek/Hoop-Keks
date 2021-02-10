using System;
using UnityEngine;

namespace Code.Core.Inputs
{
    public class JumpInput: MonoBehaviour
    {
    public event Action OnLeftJump =  delegate{};
    public event Action OnRightJump = delegate{};

    protected void LeftJump()
    {
        OnLeftJump();
    }
    protected void RightJump()
    {
        OnRightJump();
    }
    }
}