public class PlayerMovementStateMachine : StateMachine
{
    public Player Player { get; }
    public PlayerIdingState idlingState { get; private set; }
    public PlayerWalkingState walkingState { get; private set; }
    public PlayerRunningState runningState { get; private set; }
    public PlayerSprintingState sprintingState { get; private set; }

    public PlayerMovementStateMachine(Player player)
    {
        Player = player;
        idlingState = new PlayerIdingState(this);

        walkingState = new PlayerWalkingState(this);
        runningState = new PlayerRunningState(this);
        sprintingState = new PlayerSprintingState(this);
    }
}