using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Poolable
{
    public NoteContral noteContral;
    public Camera mainCamera;
    public GameObject JudgeLine;
    public bool isJudge { get; set; }
    public int NoteLine { get; set; }
    private void OnBecameInvisible()
    {
        Push();
    }

    private void Update()
    {
        NoteMove();
    }
    private void NoteMove()
    {
        this.transform.position -= new Vector3(0, mainCamera.orthographicSize * Time.deltaTime, 0f);
    }

    public void NoteDisabled()
    {
        Push();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJudge = (collision == JudgeLine) ? true : false;
        Debug.Log("ture");
    }
}
