using UnityEngine;


public class PlayerIdingState : PlayerGroundedState
{
    public PlayerIdingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region IState Methods

    public override void Enter()
    {
        base.Enter();

        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StationaryForce;

        ResetVelocity();
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            return;
        }

        OnMove();
    }

    private void OnMove()
    {
        if (stateMachine.ReusableData.ShouldWalk)
        {
            stateMachine.ChangeState((stateMachine.WalkingState));

            return;
        }

        stateMachine.ChangeState((stateMachine.RunningState));
    }

    #endregion
}