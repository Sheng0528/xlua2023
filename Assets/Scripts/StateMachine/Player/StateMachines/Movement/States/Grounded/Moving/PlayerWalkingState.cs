using UnityEngine.InputSystem;


public class PlayerWalkingState : PlayerGroundedState
{
    public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IStete Methods

    public override void Enter()
    {
        base.Enter();

        speedModifier = 0.225f;
    }

    #endregion

    #region Input Methods

    protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
        base.OnWalkToggleStarted(context);

        stateMachine.ChangeState(stateMachine.runningState);
    }

    #endregion
}