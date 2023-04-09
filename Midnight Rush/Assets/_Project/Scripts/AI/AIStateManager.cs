using UnityEngine;

public class AIStateManager : MonoBehaviour
{
    [SerializeReference] AIState[] states;
    public System.Type CurrentState { get; private set; }

    public void InitStates(Transform _target)
    {
        foreach (AIState state in states)
        {
            state.Init(_target);
            ResetStates();
        }
    }

    public TState GetState<TState>() where TState : AIState
    {
        foreach (AIState state in states)
        {
            if (state is TState tState)
                return tState;     
        }

        return null;
    }

    public AIState ApplyState<TState>() where TState : AIState
    {
        AIState newState = GetState<TState>();

        foreach (AIState state in states)
        {
            if (state == newState) continue;
            state.Disapply();
        }

        newState.Apply();
        CurrentState = typeof(TState);
        Debug.Log("Applying new state: " + CurrentState + " to: " + gameObject.name);
        return newState;
    }

    void ResetStates()
    {
        foreach (AIState state in states)
        {
            state.Disapply();
        }
    }    
}
