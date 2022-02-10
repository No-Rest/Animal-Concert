using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Poolable
{
    public NoteContral noteContral;
    public Camera mainCamera;
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

    private void NoteDisabled()
    {
        Push();
    }
}
