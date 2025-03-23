using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashingState : PlayerGroundedState
{
    private PlayerDashData dashData;
    private float startTime;
    /// <summary>
    /// 连续使用的冲刺次数
    /// </summary>
    private int consecutiveDashesUsed;
    private bool shouldKeepRotating;

    public PlayerDashingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        dashData = movementData.DashData;
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = dashData.SpeedModifier;
        
        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;

        stateMachine.ReusableData.RotationData = dashData.RotationData;

        AddForceOnTransitionFromstationaryState();
        
        shouldKeepRotating = stateMachine.ReusableData.MovementInput != Vector2.zero;
        
        UpdateConsecutiveDashes();
        
        startTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        
        SetBaseRotationData();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!shouldKeepRotating)
        {
            return;
        }
        
        RotateTowardsTargetRotation();
    }

    public override void OnAnimationEnterEvent()
    {
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.HardStoppingState);
            
            return;
        }
        
        stateMachine.ChangeState(stateMachine.SprintingState);
    }

    #region Main Methods

    private void UpdateConsecutiveDashes()
    {
        if (!isConsecutive())
        {
            consecutiveDashesUsed = 0;
        }

        ++consecutiveDashesUsed;

        if (consecutiveDashesUsed == dashData.ConsecutiveDashesLimitAmount)
        {
            consecutiveDashesUsed = 0;
            
            stateMachine.Player.Input.DisableActionFor(stateMachine.Player.Input.PlayerActions.Dash, dashData.DashLimitReachedCooldown);
        }
    }

    private bool isConsecutive()
    {
        return Time.time < startTime + dashData.TimeToBeConsiderConsecutive;
    }

    private void AddForceOnTransitionFromstationaryState()
    {
        if (stateMachine.ReusableData.MovementInput != Vector2.zero)
        {
            return;
        }
        Vector3 characterRotationDirection = stateMachine.Player.transform.forward;
        characterRotationDirection.y = 0f;

        UpdateTargetRotation(characterRotationDirection, false);

        stateMachine.Player.Rigidbody.velocity = characterRotationDirection * GetMovementSpeed();
    }

    #endregion

    #region Resuable Methods

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        
        stateMachine.Player.Input.PlayerActions.Movement.performed += OnMovementPerformed;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        
        stateMachine.Player.Input.PlayerActions.Movement.performed -= OnMovementPerformed;
    }

    #endregion

    #region Input Methods

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        
    }

    protected override void OnDashStarted(InputAction.CallbackContext context)
    {
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        shouldKeepRotating = true;
    }
    #endregion
}