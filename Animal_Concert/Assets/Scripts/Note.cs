using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public NoteControl noteContral;
    public Judge judge;
    public Camera mainCamera;
    public enum NoteJudge {Miss, Bad, Great, Perfect}
    public NoteJudge noteJudge;
    public bool isJudge;
    public int NoteLine { get; set; }
    public int NoteColor { get; set; } // 0-> Pink 1-> Blue
    public Sprite PinkNote;
    public Sprite BlueNote;

    private void Update()
    {
        NoteMove();
        if(this.transform.position.y < -730)
        {
            DestroyNote();
        }
    }
    private void OnEnable()
    {
        isJudge = false;
        noteJudge = NoteJudge.Miss;
    }
    private void NoteMove()
    {
        this.transform.position -= new Vector3(0, mainCamera.orthographicSize * Time.deltaTime, 0f);
    }

    private void DestroyNote()
    {
        ObjectPool.ReturnObject(this);
        noteContral.RemoveLine(this, NoteLine);
        judge.CurrentJudge(noteJudge.ToString());
    }
    public void ChangeColor()
    {
        switch(NoteColor)
        {
            case 0:
                this.GetComponent<SpriteRenderer>().sprite = PinkNote;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = BlueNote;
                break;
        }
    }

    public void NoteButtonClick(int LineNum, int Color)
    {
        if(LineNum == NoteLine && isJudge)
        {
            if(Color == NoteColor)
            {
                DestroyNote();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "JudgementLine")
        {
            isJudge = true;
            switch (collision.name)
            {
                case "Miss":
                    isJudge = false;
                    noteContral.RemoveLine(this, NoteLine);
                    noteJudge = NoteJudge.Miss;
                    break;
                case "Bad":
                    noteJudge = NoteJudge.Bad;
                    break;
                case "Great":
                    noteJudge = NoteJudge.Great;
                    break;
                case "Perfect":
                    noteJudge = NoteJudge.Perfect;
                    break;
            }
        }
    }
}
