using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    #region Variables
    [SerializeField] AudioSource source;
    private float startVolume;

    [SerializeField] float fadeTime;

    #endregion
    private void Start()
    {
        source = GetComponent<AudioSource>();
        startVolume = source.volume;
    }

    #region Activating audio functions
    public void PlayTheSound(AudioClip soundClip)
    {
        source.volume = startVolume;
        source.clip = soundClip;
        source.Play();
        StartCoroutine(FadeIn(source, fadeTime));
    }

    public void StopTheSound() 
    {
        StartCoroutine(FadeOut(source, fadeTime));
    }
    #endregion

    #region Fade Couroutines
    public static IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float timeElapsed = Time.time - startTime;

            audioSource.volume = Mathf.Lerp(startVolume, 0f, timeElapsed / duration);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float timeElapsed = Time.time - startTime;

            audioSource.volume = Mathf.Lerp(0f, startVolume, timeElapsed / duration);
            yield return null;
        }

        audioSource.volume = startVolume;
    }
    #endregion

}
