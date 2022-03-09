using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicInfo : MonoBehaviour //외부에서 이 스크립트의 변수에 접근하여 정보들을 모으게 하기(변경 가능), Start버튼 누르면 게임매니저에 옮겨주는 함수 적기
{
    // Start is called before the first frame update

    public int SelectedNumber;

    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    public void ChooseEasy()
    {
        gameManager.ingameInfo[0].difficulty = GameManager.Difficulty.easy;
    }
    public void ChooseNormal()
    {
        gameManager.ingameInfo[0].difficulty = GameManager.Difficulty.normal;
    }
    public void ChooseHard()
    {
        gameManager.ingameInfo[0].difficulty = GameManager.Difficulty.hard;
    }
    

}
