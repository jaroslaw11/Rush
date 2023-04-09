using UnityEngine;

public abstract class TGameStateBase : TypedStateBase
{
    [SerializeField] protected TView UIView;
    
    public override void Enter()
    {
        base.Enter();
        if (UIView != null) TViewManager.Singleton.ApplyState(UIView);
    }
}
