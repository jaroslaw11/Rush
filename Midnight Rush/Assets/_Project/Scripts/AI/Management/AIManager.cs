using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : Singleton<AIManager>
{
    AISpawner spawner;
    ObjectPool objectPool;

    protected override void Awake()
    {
        base.Awake();
        spawner = GetComponent<AISpawner>();
        objectPool = GetComponent<ObjectPool>();
        objectPool.InitPool();
    }

    public void ImDead(AIEnemy _dead)
    {
        objectPool.Return(_dead);
    }

    private void OnEnable()
    {
        spawner.StartSpawn();
    }
}
