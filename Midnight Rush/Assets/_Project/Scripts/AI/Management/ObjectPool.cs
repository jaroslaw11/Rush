using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Stack<AIEnemy> pool = new Stack<AIEnemy>();

    [SerializeField] AIEnemy[] rawPool;

    public AIEnemy Take(Transform _inGamePosition)
    {
        if (pool.Count <= 0)
        {
            Debug.LogWarning("pool is empty");
            return null;
        }

        AIEnemy newEnemy = pool.Pop();    
        newEnemy.transform.position = _inGamePosition.position;
        newEnemy.gameObject.SetActive(true);
        newEnemy.OnTake();

        return newEnemy;
    }

    public void Return(AIEnemy _enemy)
    {
        _enemy.OnReturn();
        pool.Push(_enemy);
        _enemy.gameObject.SetActive(false);
        _enemy.transform.position = transform.position;     
    }

    public void InitPool(AIEnemy[] _enemies)
    {
        foreach (AIEnemy enemy in _enemies)
            Return(enemy);
    }

    public void InitPool()
    {
        //AIEnemy[] childs = GetComponentsInChildren<AIEnemy>();
        AIEnemy[] childs = rawPool;

        Debug.Log(rawPool.Length);
        foreach (AIEnemy child in childs)
            Return(child);
    }
}
