using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public enum NoteJudge {Miss, Bad, Great, Perfect}
    public NoteJudge noteJudge;
    public NoteContral noteContral;
    public Judge judge;
    public Camera mainCamera;
    public bool isJudge;
    public int NoteLine;

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

    public void NoteButtonClick(int LineNum, int Color)
    {
        if(LineNum == NoteLine && isJudge)
        {
            DestroyNote();
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
