using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    public Currency kills;

    protected override void Awake()
    {
        base.Awake();
        kills = new Currency("Kills");
    }
}
