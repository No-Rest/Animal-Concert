using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audio;
    public double CurrentTime { get; set; }

    public void MusicPlay()
    {
        audio.Play();
    }
    public void MusicPause()
    {
        audio.Pause();
    }
    public void MusicStop()
    {
        audio.Stop();
    }

    private void MusicTime()
    {
        CurrentTime = audio.time;
    }
}
