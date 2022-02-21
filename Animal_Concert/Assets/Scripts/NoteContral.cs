using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContral : MonoBehaviour
{
    public GameObject JudgeLine;
    public DBData data;
    public Music music;
    [SerializeField]
    private int order = 0;

    public List<Note> Line1 = new List<Note>();
    public List<Note> Line2 = new List<Note>();
    public List<Note> Line3 = new List<Note>();
    public List<Note> Line4 = new List<Note>();
    public IEnumerator AwaitMakeNote(int order)
    {
        yield return new WaitForSeconds((float)data.musicData.note[order].StartTime + order * music.BeatInterval);
        NoteDispose();
    }
    public void NoteDispose()
    {
        var note = ObjectPool.GetObject();
        NoteLine(note);
        order++;
    }
    private void NoteLine(Note note)
    {
        switch(data.musicData.note[order].LineNum)
        {
            case 1:
                Line1.Add(note);
                note.transform.position = new Vector2(-450, 750);
                note.NoteLine = 1;
                break;
            case 2:
                Line2.Add(note);
                note.transform.position = new Vector2(-150, 750);
                note.NoteLine = 2;
                break;
            case 3:
                Line3.Add(note);
                note.transform.position = new Vector2(150, 750);
                note.NoteLine = 3;
                break;
            case 4:
                Line4.Add(note);
                note.transform.position = new Vector2(450, 750);
                note.NoteLine = 4;
                break;
        }
    }

    public void NoteDisabled()
    {
/*        if(JudgeLine.transform.position.y >= )*/
    }
}
