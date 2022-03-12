using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteButton : MonoBehaviour
{
    public NoteContral noteContral;
    public int LineNum;
    public int Color;

    public void DisableNote()
    {
        noteContral.NoteButtonClick(LineNum, Color);
    }
}
