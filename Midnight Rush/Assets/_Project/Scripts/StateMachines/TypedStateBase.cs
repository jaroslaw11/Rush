using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TypedStateBase : MonoBehaviour
{
    public abstract void Initialize();

    public virtual void Exit()
    {
        gameObject.SetActive(false);
        OnExit();
    }


    public virtual void Enter()
    {
        gameObject.SetActive(true);
        OnEnter();
        Debug.Log(this.name + " is applied");
    }

    public virtual void OnEnter() { }

    public virtual void OnExit() { }
}
