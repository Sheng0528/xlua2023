﻿using UnityEngine;

public abstract class StateMachine
{
    protected IState currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        //===currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
    
    public void OnAnimationEnterEvent()
    {
        currentState?.OnAnimationEnterEvent();
    }
    
    public void OnAnimationExitEvent()
    {
        currentState?.OnAnimationExitEvent();
    }
    
    public void OnAnimationTransitionEvent()
    {
        currentState?.OnAnimationTransitionEvent();
    }
    
    public void OnTriggerEnter(Collider collider)
    {
        currentState.OnTriggerEnter(collider);
    }
    
    public void OnTriggerExit(Collider collider)
    {
        currentState.OnTriggerExit(collider);
    }
}