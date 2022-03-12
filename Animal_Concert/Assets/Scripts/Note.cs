using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public enum NoteJudge {Miss, Bad, Great, Perfect}
    public NoteJudge noteJudge;
    public NoteContral noteContral;
    public Camera mainCamera;
    public GameObject JudgeLine;
    public bool isJudge;
    public int NoteLine;


    private void Update()
    {
        NoteMove();
    }
    private void NoteMove()
    {
        this.transform.position -= new Vector3(0, mainCamera.orthographicSize * Time.deltaTime, 0f);
    }

    private void DestroyNote()
    {
        ObjectPool.ReturnObject(this);
        Debug.Log(noteJudge);
    }

    public void NoteButtonClick(int LineNum, int Color)
    {
        if(LineNum == NoteLine && isJudge)
        {
            DestroyNote();
        }
    }
    private void OnBecameInvisible()
    {
        DestroyNote();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "JudgementLine")
        {
            isJudge = true;
            switch (collision.name)
            {
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        noteContral.RemoveLine(this, NoteLine);
        noteJudge = NoteJudge.Miss;
        if (collision.tag == "JudgementLine")
        {
            isJudge = false;
        }
    }
}
