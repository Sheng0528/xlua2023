using UnityEngine.InputSystem;

public class PlayerSprintingState : PlayerMovingState
{
    
    private PlayerSprintData sprintData;
    private bool keepSprinting;
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
    }

    public override void Update()
    {
        base.Update();

        if (keepSprinting)
        {
            return;
        }
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


    #endregion

    #region Input Methods
    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        keepSprinting = true;
    }

    #endregion
}