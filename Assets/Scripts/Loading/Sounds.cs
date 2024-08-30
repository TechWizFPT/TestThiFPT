using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : Singleton<Sounds>
{
    [SerializeField] AudioSource audioSource;
    public AudioClip SFX_btn_click;
    protected override void Start()
    {
        base.Start();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
