using System;
using UnityEngine;


[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [field:Header("Referrences")]
    [field:SerializeField]public PlayerSO Data { get; private set; }
    [field:Header("Collisions")]
    [field:SerializeField] public CapsuleColliderUtility ColliderUtility { get; private set; }
    [field:SerializeField] public PlayerLayerData LayerData { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Transform MainCameraTransform { get; private set; }
    public PlayerInput Input { get; private set; }
    private PlayerMovementStateMachine movementStateMachine;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<PlayerInput>();
        
        MainCameraTransform = Camera.main.transform;
        movementStateMachine = new PlayerMovementStateMachine(this);
    }

    private void OnValidate()
    {
        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();
    }

    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.idlingState);
    }

    private void Update()
    {
        movementStateMachine.HandleInput();

        movementStateMachine.Update();
    }

    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdate();
    }
}