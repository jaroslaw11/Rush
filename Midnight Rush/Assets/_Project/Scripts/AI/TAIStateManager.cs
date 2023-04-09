using UnityEngine;

public class TAIStateManager : TypedStateMachine <TAIState>
{
    public void SetTarget(Transform _target)
    {
        foreach (TAIState state in states)
        {
            state.SetTarget(_target);
        }
    }
}
