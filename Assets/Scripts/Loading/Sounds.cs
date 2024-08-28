using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : Singleton<Sounds>
{
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
