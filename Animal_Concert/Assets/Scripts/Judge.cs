using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{ 
    public Text ComboText;
    public Text JudgeText;
    public Text ScoreText;
    public Image HP_Fill;
    private int Score = 0;
    private int Combo = 0;
    private void ChangeScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
    }
    private void ChangeHP(float hp)
    {
        HP_Fill.fillAmount += hp;
    }
    
    private void ChangeCombo(int combo)
    {
        Combo += combo;
        ComboText.text = Combo.ToString();
    }
    private void ChangeJudge(string judge)
    {
        JudgeText.text = judge;
    }
    public void CurrentJudge(string judge)
    {
        switch(judge)
        {
            case "Miss":
                Combo = 0;
                ComboText.text = null;
                ChangeHP(-0.1f);
                ChangeJudge("MISS");
                break;
            case "Bad":
                ChangeScore(1);
                ChangeCombo(1);
                ChangeJudge("BAD");
                break;
            case "Great":
                ChangeScore(5);
                ChangeCombo(1);
                ChangeJudge("GREAT");
                break;
            case "Perfect":
                ChangeScore(10);
                ChangeCombo(1);
                ChangeHP(0.01f);
                ChangeJudge("PERFECT");
                break;
        }
    }
}
