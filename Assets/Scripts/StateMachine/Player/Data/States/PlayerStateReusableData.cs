using System;
using UnityEngine;

[Serializable]
public class PlayerStateReusableData
{
    public Vector2 MovementInput { get; set; }

    public float MovementSpeedModifier { get; set; } = 1f;
    
    public float MovementOnSlopesSpeedModifier { get; set; } = 1f;
    
    public float MovementDecelerationForce { get; set; } = 1f;

    public bool ShouldWalk { get; set; }
    public bool ShouldSprint { get; set; }

    private Vector3 currentTargetRotation;
    private Vector3 timeToReachTargetRotation;
    private Vector3 dampTargetRotationCurrentVelocity;
    private Vector3 dampTargetRotationPassTime;

    public ref Vector3 CurrentTargetRotation
    {
        get { return ref currentTargetRotation; }
    }

    public ref Vector3 TimeToReachTargetRotation
    {
        get { return ref timeToReachTargetRotation; }
    }

    public ref Vector3 DampTargetRotationCurrentVelocity
    {
        get { return ref dampTargetRotationCurrentVelocity; }
    }

    public ref Vector3 DampTargetRotationPassTime
    {
        get { return ref dampTargetRotationPassTime; }
    }
    
    public Vector3 CurrentJumpForce { get; set; }

    public PlayerRotationData RotationData { get; set; }
}