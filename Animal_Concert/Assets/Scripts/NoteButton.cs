using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteButton : MonoBehaviour
{
    public Text Score;
    public static int ScoreValue;
    public NoteContral noteContral;
    [SerializeField]
    private GameObject[] pinkButton;
    [SerializeField]
    private GameObject[] blueButton;

    void Start()
    {
        pinkButton = GameObject.FindGameObjectsWithTag("PinkButton");
        blueButton = GameObject.FindGameObjectsWithTag("BlueButton");
    }

    public void DisableNote()
    {
        for(int i = 0; i < pinkButton.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject == pinkButton[i])
            {
                ScoreValue += 100;
                switch (i)
                {
                    case 0:
                        if(noteContral.Line1[0].isJudge)
                        {
                            noteContral.Line1[0].DestroyNote();
                            Score.text = ScoreValue.ToString();
                        }
                        break;
                    case 1:
                        if (noteContral.Line2[0].isJudge)
                        {
                            noteContral.Line2[0].DestroyNote();
                            Score.text = ScoreValue.ToString();
                        }
                        break;
                    case 2:
                        if (noteContral.Line3[0].isJudge)
                        {
                            noteContral.Line3[0].DestroyNote();
                            Score.text = ScoreValue.ToString();
                        }
                        break;
                    case 3:
                        if (noteContral.Line4[0].isJudge)
                        {
                            noteContral.Line4[0].DestroyNote();
                            Score.text = ScoreValue.ToString();
                        }
                        break;
                }
            }         
        }
    }
}
