using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    public GameObject JudgeLine;
    public DBData data;
    public Music music;
    [SerializeField]
    private int order = 0;
    public List<Note> Line1;
    public List<Note> Line2;
    public List<Note> Line3;
    public List<Note> Line4;

    public IEnumerator AwaitMakeNote(int order)
    {
        yield return new WaitForSeconds((float)data.musicData.note[order].StartTime + order * music.BeatInterval);
        NoteDispose();
    }
    public void NoteDispose()
    {
        var note = ObjectPool.GetObject();
        NoteLine(note);
        note.ChangeColor();
        order++;
    }
    public void RemoveLine(Note note, int LineNum)
    {
        Line(LineNum).Remove(note);
    }
    public void NoteButtonClick(int LineNum, int Color)
    {
        if(Line(LineNum).Count > 0)
        {
            Line(LineNum)[0].NoteButtonClick(LineNum, Color);
        }
    }

    private List<Note> Line(int LineNum)
    {
        switch (LineNum)
        {
            case 1:
                return Line1;
            case 2:
                return Line2;
            case 3:
                return Line3;
            case 4:
                return Line4;
            default:
                return null;
        }
    }
    private void NoteLine(Note note)
    {
        note.NoteLine = data.musicData.note[order].LineNum;
        note.NoteColor = data.musicData.note[order].Color;
        switch (data.musicData.note[order].LineNum)
        {
            case 1:
                note.transform.position = new Vector2(-450, 750);
                Line1.Add(note);
                break;
            case 2:
                note.transform.position = new Vector2(-150, 750);
                Line2.Add(note);
                break;
            case 3:
                note.transform.position = new Vector2(150, 750);
                Line3.Add(note);
                break;
            case 4:
                note.transform.position = new Vector2(450, 750);
                Line4.Add(note);
                break;
        }
    }

}
