using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnPosition : MonoBehaviour
{
    [SerializeField] ParticleSystem spawnFX;

    public void PlaySpawnFX()
    {
        spawnFX.gameObject.SetActive(true);
    }
}
