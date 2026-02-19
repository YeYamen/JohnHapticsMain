using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayTheSound(AudioClip soundClip)
    {
        source.PlayOneShot(soundClip);
    }

    public void StopTheSound() 
    {
        source.Stop();
    }

}
