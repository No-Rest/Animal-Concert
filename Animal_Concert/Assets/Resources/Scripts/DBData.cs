using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class NoteData
{
    public int Order;
    public int Type; // 0-> short 1-> long
    public int Color; // 0-> red 1-> blue
    public int LineNum;
    public double StartTime;
    public double EndTime; //long노트 사용시 사용

    public NoteData(int order, int type, int color, int Line, double start, double end)
    {
        Order = order;
        Type = type;
        Color = color;
        LineNum = Line;
        StartTime = start;
        EndTime = end;
    }
}
[System.Serializable]
public class MusicData
{
    public string Music;
    public float BPM;
    public int noteCount;
    public List<NoteData> note = new List<NoteData>();
}

public class DBData : MonoBehaviour
{
    public MusicData musicData;
    [ContextMenu("To Json Data")]
    public void SaveNoteData()
    {
        string jsonData = JsonUtility.ToJson(musicData, true);
        string path = Path.Combine(Application.dataPath + "/Resources/Music/" + musicData.Music + "Data.json");
        File.WriteAllText(path, jsonData);
    }
    public void LoadNoteData()
    {
        string path = Path.Combine(Application.dataPath + "/Resources/Music/" + "Welcome To My Garden" + "Data.json");
        string jsonData = File.ReadAllText(path);
        musicData = JsonUtility.FromJson<MusicData>(jsonData);

    }

    private void Awake()
    {
        LoadNoteData();
    }
}
