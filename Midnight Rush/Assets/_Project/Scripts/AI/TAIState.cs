using UnityEngine;
using RootMotion.Dynamics;

public abstract class TAIState : TypedStateBase
{
    protected Animator animator;
    protected Transform target;

    protected abstract void UpdateAnimation();

    public override void Initialize()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public override void Enter()
    {
        enabled = true;
        UpdateAnimation();
    }

    public override void Exit()
    {
        enabled = false;
    }
}
