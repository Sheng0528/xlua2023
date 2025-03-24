using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerAirborneState
{
    private bool shouldKeepRotating;
    public PlayerJumpingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IState Methods
    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        shouldKeepRotating = stateMachine.ReusableData.MovementInput != Vector2.zero;
        Jump();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (shouldKeepRotating)
        {
            RotateTowardsTargetRotation();
        }
    }

    #endregion

    #region Main Methods

    private void Jump()
    {
        Vector3 jumpForce = stateMachine.ReusableData.CurrentJumpForce;
        
        Vector3 jumpDirection = stateMachine.Player.transform.forward;

        if (shouldKeepRotating)
        {
            jumpDirection = GetTargetRotationDirection(stateMachine.ReusableData.CurrentTargetRotation.y);
        }

        jumpForce.x *= jumpDirection.x;
        jumpForce.z *= jumpDirection.z;
        
        ResetVelocity();
        
        stateMachine.Player.Rigidbody.AddForce(jumpForce, ForceMode.VelocityChange);
    }
    

    #endregion
}
