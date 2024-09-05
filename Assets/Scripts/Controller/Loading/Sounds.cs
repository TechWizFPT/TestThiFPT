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
        CheckAudioSource();
    }

    public void PlaySound(AudioClip clip)
    {
        CheckAudioSource();
        audioSource.PlayOneShot(clip);
    }

    void CheckAudioSource()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();

        }
    }
}
