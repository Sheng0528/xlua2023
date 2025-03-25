using System;
using UnityEngine;

[Serializable]
public class PlayerGroundedData
{
    [field: SerializeField]
    [field: Range(0f, 25f)]
    public float BaseSpeed { get; private set; } = 5f;
    
    [field: SerializeField]
    [field: Range(0f, 25f)]
    public float GroudToFallRayDistance { get; private set; } = 1f;

    [field: SerializeField] public AnimationCurve SlopeSpeedAngles { get; private set; }
    [field: SerializeField] public PlayerRotationData BaseRotationData { get; private set; }
    [field: SerializeField] public PlayerWalkData WalkData { get; private set; } 
    [field: SerializeField] public PlayerRunData RunData { get; private set; }
    [field: SerializeField] public PlayerSprintData SprintData { get; private set; }
    [field: SerializeField] public PlayerDashData DashData { get; private set; }
    [field: SerializeField] public PlayerStopData StopData { get; private set; }
}