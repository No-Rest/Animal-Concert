using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButton : MonoBehaviour
{
    public Transform PinkButton;
    public Transform BlueButton;
    [SerializeField]
    private Transform[] pinkButton;
    [SerializeField]
    private Transform[] blueButton;
    // Start is called before the first frame update
    void Start()
    {
        pinkButton = PinkButton.gameObject.GetComponentsInChildren<Transform>();
        blueButton = BlueButton.gameObject.GetComponentsInChildren<Transform>();
    }

    public void Disable()
    {
        Note note = GameObject.FindGameObjectWithTag("Note").GetComponent<Note>();
        Debug.Log("disable");

        if (note.isJudge)
        {
            note.NoteDisabled();
        }

    }
}
