using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintingState : PlayerMovingState
{
    private PlayerSprintData sprintData;
    private float startTime;
    private bool keepSprinting;
    private bool shouldResetSprintState;

    public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(
        playerMovementStateMachine)
    {
        sprintData = movementData.SprintData;
    }


    #region Istate Methods

    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = sprintData.SpeedModifier;

        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;

        shouldResetSprintState = true;

        startTime = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (keepSprinting)
        {
            return;
        }

        if (Time.time < startTime + sprintData.SprintToRunTime)
        {
            return;
        }

        StopSprinting();
    }

    public override void Exit()
    {
        base.Exit();

        if (shouldResetSprintState)
        {
            keepSprinting = false;
            stateMachine.ReusableData.ShouldSprint = false;
        }
    }

    #endregion

    #region Main Methods

    private void StopSprinting()
    {
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);

            return;
        }

        stateMachine.ChangeState(stateMachine.RunningState);
    }

    #endregion

    #region Resuable Methods

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Sprint.performed += OnSprintPerformed;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Sprint.performed -= OnSprintPerformed;
    }

    protected override void OnFall()
    {
        shouldResetSprintState = false;
        base.OnFall();
    }

    #endregion

    #region Input Methods

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.HardStoppingState);
    }

    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        keepSprinting = true;

        stateMachine.ReusableData.ShouldSprint = true;
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        shouldResetSprintState = false;
        base.OnJumpStarted(context);
    }

    #endregion
}