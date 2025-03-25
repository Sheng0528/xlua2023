using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerAirborneState
{
    public PlayerFallingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IState Methods

    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = 0f;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        LimitVerticalVelocity();
    }

    #endregion

    #region Main Methods

    private void LimitVerticalVelocity()
    {
        
    }
    #endregion
}
