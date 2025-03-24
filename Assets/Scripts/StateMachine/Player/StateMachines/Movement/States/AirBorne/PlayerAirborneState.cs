using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState : PlayerMovementState
{
    public PlayerAirborneState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Resuable Methods

    protected override void OnContactWithGround(Collider collider)
    {
        stateMachine.ChangeState(stateMachine.IdlingState);
    }

    #endregion
}
