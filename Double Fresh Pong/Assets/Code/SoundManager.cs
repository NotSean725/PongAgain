using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource serveAudio;
    public AudioSource hitAudio;
    public AudioSource pointScoredAudio;
    public AudioSource winAudio;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayServeSound()
    {
        serveAudio.Play();
    }

    public void PlayHitSound()
    {
        hitAudio.Play();
    }

    public void PlayPointScoredSound()
    {
        pointScoredAudio.Play();
    }

    public void PlayWinSound()
    {
        winAudio.Play();
    }
}
