using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContral : MonoBehaviour
{
    public GameObject JudgeLine;
    public DBData data;
    public Music music;
    [SerializeField]
    private int order = 0;

    public IEnumerator AwaitMakeNote(int order)
    {
        yield return new WaitForSeconds((float)data.musicData.note[order].StartTime + order * music.BeatInterval);
        NoteDispose();
    }
    public void NoteDispose()
    {
        ObjectPoolManager.Instance.pool.Pop().transform.position = NoteLine();
        ObjectPoolManager.Instance.pool.GetComponent<Note>().NoteLine = data.musicData.note[order].LineNum;
        order++;
    }
    public Vector2 NoteLine()
    {
        Vector2 Location; 
        switch(data.musicData.note[order].LineNum)
        {
            case 1:
                Location = new Vector2(-450, 750);
                break;
            case 2:
                Location = new Vector2(-150, 750);
                break;
            case 3:
                Location = new Vector2(150, 750);
                break;
            case 4:
                Location = new Vector2(450, 750);
                break;
            default:
                Location = new Vector2(0, 0);
                break;
        }
        return Location;

    }

    public void NoteDisabled()
    {
/*        if(JudgeLine.transform.position.y >= )*/
    }
}
