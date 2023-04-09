using UnityEngine;

public abstract class TypedStateMachine<TStateBase> : MonoBehaviour where TStateBase : TypedStateBase
{
    [SerializeField] protected TStateBase[] states;

    public TStateBase CurrentState { get; private set; }

    public T GetState<T>() where T : TStateBase
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i] is T tTStateBase)
                return tTStateBase;
        }

        return null;
    }

    public TStateBase ApplyState<T>() where T : TStateBase
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i] is T tTStateBase)
            {
                if (CurrentState != null)
                    CurrentState.Exit();

                states[i].Enter();
                CurrentState = states[i];
            }
        }

        return CurrentState;
    }

    public void ApplyState(TStateBase _TStateBase)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        _TStateBase.Enter();
        CurrentState = _TStateBase;
    }

    protected void StartInit()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].Initialize();
            states[i].Exit();
        }
    }

    public void ResetStates()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].Exit();
        }
    }

    public void InitStates()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].Initialize();
        }
    }
}
