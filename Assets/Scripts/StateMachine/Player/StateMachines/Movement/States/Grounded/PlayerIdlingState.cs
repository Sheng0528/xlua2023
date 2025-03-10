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

        speedModifier = 0f;

        ResetVelocity();
    }

    public override void Update()
    {
        base.Update();

        if (movementInput == Vector2.zero)
        {
            return;
        }

        OnMove();
    }

    private void OnMove()
    {
        if (shouldWalk)
        {
            stateMachine.ChangeState((stateMachine.walkingState));

            return;
        }

        stateMachine.ChangeState((stateMachine.runningState));
    }

    #endregion
}