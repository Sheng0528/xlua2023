using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDashData
{
    /// <summary>
    /// 冲刺速度
    /// </summary>
    [field: SerializeField]
    [field: Range(1f, 3f)]
    public float SpeedModifier { get; private set; } = 2f;
    
    /// <summary>
    /// 连续冲刺的时间
    /// </summary>
    [field: SerializeField]
    [field: Range(0f, 2f)]
    public float TimeToBeConsiderConsecutive { get; private set; } = 2f;
    
    /// <summary>
    /// 连续冲刺的次数
    /// </summary>
    [field: SerializeField]
    [field: Range(1, 10)]
    public int ConsecutiveDashesLimitAmount { get; private set; } = 2;
    
    /// <summary>
    /// 冷却时间
    /// </summary>
    [field: SerializeField]
    [field: Range(0f, 5f)]
    public float DashLimitReachedCooldown { get; private set; } = 1.75f;
    
    [field:SerializeField]public PlayerRotationData RotationData { get; private set; }
}