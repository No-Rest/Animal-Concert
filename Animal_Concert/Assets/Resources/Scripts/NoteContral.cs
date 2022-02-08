using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContral : MonoBehaviour
{
    public DBData data;
    [SerializeField]
    private int NoteCount = -1;
    public void NoteDispose()
    {
        ObjectPoolManager.Instance.pool.Pop().transform.position = NoteLine();
    }
    public Vector2 NoteLine()
    {
        NoteCount++;
        Vector2 Location;
        switch(data.musicData.note[NoteCount].LineNum)
        {
            case 1:
                Location = new Vector2(-450, 0);
                break;
            case 2:
                Location = new Vector2(-150, 0);
                break;
            case 3:
                Location = new Vector2(150, 0);
                break;
            case 4:
                Location = new Vector2(450, 0);
                break;
            default:
                Location = new Vector2(0, 0);
                break;
        }
        return Location;

    }
}
