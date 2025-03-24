using UnityEngine;

public interface IState
{
    public void Enter();

    public void Exit();

    public void HandleInput();
    public void Update();
    public void PhysicsUpdate();
    public void OnAnimationEnterEvent();
    public void OnAnimationExitEvent();
    /// <summary>
    /// 动画转换事件
    /// </summary>
    public void OnAnimationTransitionEvent();

    public void OnTriggerEnter(Collider collider);
}