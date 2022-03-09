using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Text LoadingPercent;
    public float dg;
    private AsyncOperation op;
    
    public float timer = 0.0f;
    public float Speed;
    public bool isDone;
    void Start()
    {
        op = SceneManager.LoadSceneAsync("Play");
        op.allowSceneActivation = false; //이게 false면 progress는 0.9에서 멈추고, true로 되어야 isDone이 true가 됨
        
        StartCoroutine(LoadScene());
        StartCoroutine(WaitForLoading());
        
    }

    // Update is called once per frame
    void Update()
    {
        dg = op.progress;
        if(op.isDone)
            Debug.Log("성공");
    }

    IEnumerator WaitForLoading() //로딩시간 일부러 늘리는 함수
    {
        int loopNum = 0;

        

        while (true)
        {
            timer += Time.deltaTime * Speed * 100;
            LoadingPercent.text = (int)timer + "%";
            if(loopNum++ > 10000)
                throw new System.Exception("Infinite Loop");
            if (timer > 99)
            {
                LoadingPercent.text = 100 + "%";
                yield return new WaitForSeconds(1f); 
                break;
                
            }
            yield return null; 
        }

        while (!isDone)//혹시 인위적으로 늘린 시간이 지났는데도 로딩이 안끝났을 때 기다려주는 것 
        {
            yield return null;
        }
        
        op.allowSceneActivation = true;
        yield return null; 
    }
    IEnumerator LoadScene()//실제 로딩시간
    {
        
        
        
        
        while (!op.isDone)
        {
            //LoadingPercent.text = ((int)op.progress * 100) + "%";
            
            //dg = (int)op.progress * 100;

            if (op.progress >= 0.89)
            {
                isDone = true;
                yield break;
            }
            yield return null; 
        }
        //LoadingPercent.text = "100%";
        
    }
    

    
}
