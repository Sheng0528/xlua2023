using System;
using UnityEngine;


[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [field:Header("Referrences")]
    [field:SerializeField]public PlayerSO Data { get; private set; }
    [field:Header("Collisions")]
    [field:SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
    [field:SerializeField] public PlayerLayerData LayerData { get; private set; }
    [field:Header("Cameras")]
    [field:SerializeField] public PlayerCameraUtility CameraUtility { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Transform MainCameraTransform { get; private set; }
    public PlayerInput Input { get; private set; }
    private PlayerMovementStateMachine movementStateMachine;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<PlayerInput>();

        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();
        CameraUtility.Initialize();
        
        MainCameraTransform = Camera.main.transform;
        movementStateMachine = new PlayerMovementStateMachine(this);
    }

    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void OnTriggerEnter(Collider collider)
    {
        movementStateMachine.OnTriggerEnter(collider);
    }
    
    private void OnTriggerExit(Collider collider)
    {
        movementStateMachine.OnTriggerExit(collider);
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