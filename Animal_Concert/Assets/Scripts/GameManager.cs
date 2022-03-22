using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JudgeCount
{
    public int MissCount { get; set; }
    public int BadCount { get; set; }
    public int GoodCount { get; set; }
    public int ExcellentCount { get; set; }
    public int MaxComboCount { get; set; }
    public int TotalScoreCount { get; set; }

    public JudgeCount(int missCount, int badCount, int goodCount, int excellentCount, int maxComboCount, int totalScore)
    {
        MissCount = missCount;
        BadCount = badCount;
        GoodCount = goodCount;
        ExcellentCount = excellentCount;
        MaxComboCount = maxComboCount;
        TotalScoreCount = totalScore;
    }
}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    [System.Serializable]
    public class InGameInfo //get set 필요하면 넣기
    {
        private string Title;
        public Difficulty difficulty;
        public bool isPlay;
    }

    public InGameInfo[] ingameInfo;
    
    public enum Difficulty
    {
        easy,
        normal,
        hard
    };
    
    public static GameManager instance = null; 
    private void Awake() 
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this) 
                Destroy(this.gameObject);
        } 
    }

/*    public int MissCount { get; set; }
    public int BadCount { get; set; }
    public int Good { get; set; }
    public int Excellent { get; set; }
    public int MaxCombo { get; set; }*/
    public UIManager uimanager;

    public JudgeCount judgeCount;
    private void EndGame()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
