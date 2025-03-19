public class PlayerMovementStateMachine : StateMachine
{
    public Player Player { get; }
    public PlayerStateReusableData ReusableData { get; }
    public PlayerIdingState idlingState { get; private set; }
    public PlayerDashingState dashingState { get; private set; }
    public PlayerWalkingState walkingState { get; private set; }
    public PlayerRunningState runningState { get; private set; }
    public PlayerSprintingState sprintingState { get; private set; }

    public PlayerMovementStateMachine(Player player)
    {
        Player = player;
        ReusableData = new PlayerStateReusableData();
        idlingState = new PlayerIdingState(this);
        dashingState = new PlayerDashingState(this);
        walkingState = new PlayerWalkingState(this);
        runningState = new PlayerRunningState(this);
        sprintingState = new PlayerSprintingState(this);
    }
}