using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.ProBuilder;

public class PlayerFallingState : PlayerAirborneState
{
    private PlayerFallData fallData;
    private Vector3 playerPositionOnEnter;

    public PlayerFallingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        fallData = airborneData.FallData;
    }

    #region IState Methods

    public override void Enter()
    {
        base.Enter();

        playerPositionOnEnter = stateMachine.Player.transform.position;

        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        ResetVerticalVelocity();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        LimitVerticalVelocity();
    }

    #endregion

    #region Resuable Methods

    protected override void ResetSprintState()
    {
    }

    protected override void OnContactWithGround(Collider collider)
    {
        float fallDistance = MathF.Abs(playerPositionOnEnter.y - stateMachine.Player.transform.position.y);

        if (fallDistance < fallData.MinimumDistanceToBeConsiderHardFall)
        {
            stateMachine.ChangeState(stateMachine.LightLandingState);

            return;
        }

        if (stateMachine.ReusableData.ShouldWalk &&
            !stateMachine.ReusableData.ShouldSprint ||
            stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.HardLandingState);
            return;
        }
        
        stateMachine.ChangeState(stateMachine.RollingState);
    }

    #endregion

    #region Main Methods

    private void LimitVerticalVelocity()
    {
        Vector3 playerVelocity = GetPlayerVerticalVelocity();
        if (stateMachine.Player.Rigidbody.velocity.y >= -fallData.FallSpeedLimit)
        {
            return;
        }

        Vector3 limitedVelocity =
            new Vector3(0f, -fallData.FallSpeedLimit - stateMachine.Player.Rigidbody.velocity.y, 0f);

        stateMachine.Player.Rigidbody.AddForce(limitedVelocity, ForceMode.VelocityChange);
    }

    #endregion
}