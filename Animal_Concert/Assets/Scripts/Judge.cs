using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    public Text ScoreText;
    public Image HP_Fill;
    private int Score = 0;
    private void ChangeScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
    }
    private void ChangeHP(float hp)
    {
        HP_Fill.fillAmount += hp;
    }
    
    public void CurrentJudge(string judge)
    {
        switch(judge)
        {
            case "Miss":
                ChangeHP(-0.1f);
                break;
            case "Bad":
                ChangeScore(1);
                break;
            case "Great":
                ChangeScore(5);
                break;
            case "Perfect":
                ChangeScore(10);
                ChangeHP(0.01f);
                break;
        }
    }
}
