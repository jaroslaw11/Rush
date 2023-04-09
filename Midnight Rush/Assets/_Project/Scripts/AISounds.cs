using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISounds : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip onRebornSound;
    [SerializeField] AudioClip startAttackSound;
    [SerializeField] AudioClip deathSound;

    public void PlayReborn()
    {
        source.clip = onRebornSound;
        source.Play();
    }

    public void PlayAttack()
    {
        source.clip = startAttackSound;
        source.Play();
    }

    public void PlayDeath()
    {
        source.clip = deathSound;
        source.Play();
    }
}
