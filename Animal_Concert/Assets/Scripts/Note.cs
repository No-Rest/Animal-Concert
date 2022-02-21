using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
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

    public void DestroyNote()
    {
        ObjectPool.ReturnObject(this);
        switch (NoteLine)
        {
            case 1:
                noteContral.Line1.Remove(noteContral.Line1[0]);
                break;
            case 2:
                noteContral.Line2.Remove(noteContral.Line2[0]);
                break;
            case 3:
                noteContral.Line3.Remove(noteContral.Line3[0]);
                break;
            case 4:
                noteContral.Line4.Remove(noteContral.Line4[0]);
                break;
        }
    }

/*    private void OnBecameInvisible()
    {
        DestroyNote();
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == JudgeLine)
        {
            isJudge = true;
            Debug.Log("ture");
        }
    }
}
