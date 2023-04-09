using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class AISpawner : MonoBehaviour
{
    ObjectPool pool;
    public AISpawnStage[] spawnStages;
   
    IEnumerator Spawn()
    {
        while (true)
        {
            AISpawnStage stage = spawnStages[Random.Range(0, spawnStages.Length - 1)];
            foreach (var preset in stage.presets)
            {
                for (int i = 0; i < preset.count; i++)
                {
                    pool.Take(preset.position);
                    preset.position.GetComponent<AISpawnPosition>().PlaySpawnFX();
                }
            }

            yield return new WaitForSeconds(stage.delayAfter);
        }
    }

    public void StartSpawn()
    {
        pool = GetComponent<ObjectPool>();
        StartCoroutine(Spawn());
    }
}
