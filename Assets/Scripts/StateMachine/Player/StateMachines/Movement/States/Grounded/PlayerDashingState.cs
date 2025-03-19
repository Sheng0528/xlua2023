using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashingState : PlayerGroundedState
{
    private PlayerDashData dashData;
    private float startTime;
    private int consecutiveDashesUsed;

    public PlayerDashingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        dashData = movementData.DashData;
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = dashData.SpeedModifier;

        AddForceOnTransitionFromstationaryState();
        
        UpdateConsecutiveDashes();
        
        startTime = Time.time;
    }

    public override void OnAnimationEnterEvent()
    {
        base.OnAnimationEnterEvent();

        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.idlingState);
            
            return;
        }
        
        stateMachine.ChangeState(stateMachine.sprintingState);
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

        stateMachine.Player.Rigidbody.velocity = characterRotationDirection * GetMovementSpeed();
    }

    #endregion

    #region Input Methods

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        
    }

    protected override void OnDashStarted(InputAction.CallbackContext context)
    {
    }

    #endregion
}