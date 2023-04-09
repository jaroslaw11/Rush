using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T :MonoBehaviour
{
    public static T _instance { get; private set; }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}
