using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audio;
    public DBData data;
    public NoteControl noteContral;
    public bool isPlay { get; set; } //GameManager에 넣기
    public double CurrentTime { get; set; }
    float timeLastFrame = 0;
    public float BeatTempo { get; set; }
    public float BeatInterval { get; set; }
    private void Start()
    {
        Beat();
    }
    private void Update()
    {
        CurrentTime = audio.time - timeLastFrame;
        timeLastFrame = audio.time;
    }
    public void MusicPlay()
    {
        audio.Play();

        isPlay = true;
        for (int i = 0; i < data.musicData.note.Count; i++)//GameManaer로 ++ 라인별로 만들어 수정
        {
            StartCoroutine(noteContral.AwaitMakeNote(i));
        }
    }
    public void MusicPause()
    {
        audio.Pause();
        isPlay = false;
    }
    public void MusicStop()
    {
        audio.Stop();
        isPlay = false;
    }
    
    private void Beat()
    {
        BeatTempo = data.musicData.BPM / 60;
        BeatInterval = BeatTempo / 60;
    }

    private void MusicTime()
    {
        CurrentTime = audio.time;
    }
}
