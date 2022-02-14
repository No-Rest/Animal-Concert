using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
