using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : Singleton<UISounds>
{
    public AudioClip onHoverSound;
    public AudioClip onClickSound;
    [SerializeField] AudioSource source;

    public void PlayOnHover()
    {
        source.clip = onHoverSound;
        source.Play();
    }

    public void PlayOnClick()
    {
        source.clip = onClickSound;
        source.Play();
    }
}
