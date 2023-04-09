using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Stat <TValue>
{
    public UnityEvent m_StatChanged;

    protected string saveName;

    public TValue Value { get; protected set; }

    public Stat(string _saveName)
    {
        m_StatChanged = new UnityEvent();
        saveName = _saveName;
    }
}
