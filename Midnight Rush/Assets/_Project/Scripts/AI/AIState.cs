using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AIState : MonoBehaviour
{
    protected Animator animator;
    protected Transform target;

    public virtual void Init(Transform _target)
    {
        animator = GetComponent<Animator>();
        target = _target;
    }

    public virtual void Apply()
    {
        enabled = true;
        UpdateAnimation();    
    }

    public virtual void Disapply() 
    { 
        enabled = false; 
    }

    protected abstract void UpdateAnimation();
}
