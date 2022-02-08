using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Poolable
{
    public NoteContral noteContral;
    private void OnBecameInvisible()
    {
        Push();
    }

    private void NoteMove()
    {
        this.transform.Translate(Vector3.down * 0.5f);
    }

    private void NoteDisabled()
    {
        Push();
    }
}
