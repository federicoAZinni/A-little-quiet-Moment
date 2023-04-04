using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager ins;
    public AudioSource audioSource;
    public AudioClip gameClip;
    public AudioClip menuClip;
    public AudioClip comicClip;


    private void Awake()
    {
        ins = this;
    }

    public void PlayMenu()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(menuClip);
    }
    public void PlayGame()
    {
        audioSource.Stop();
        audioSource.clip = gameClip;
        audioSource.Play();
    }
    public void PlayComic()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(comicClip);
    }
}
