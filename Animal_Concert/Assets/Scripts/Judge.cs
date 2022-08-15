using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    public UIManager uiManager;
    public GameManager gameManager;
    public Text ComboText;
    public Text JudgeText;
    public Text ScoreText;
    public Image HP_Fill;
    public float AlphaTime = 2f;
    private int Score { get; set; }
    private int Combo { get; set; }

    private void ChangeScore(int score)
    {
        Score += score;
        gameManager.judgeCount.MaxComboCount = Score;
        ScoreText.text = Score.ToString();
    }
    private void ChangeHP(float hp)
    {
        HP_Fill.fillAmount += hp;
    }
    
    private void ChangeJudgeText(string judge)
    {
        Color ComboColor = ComboText.GetComponent<Text>().color;
        Color JudgeColor = JudgeText.GetComponent<Text>().color;
        ComboText.GetComponent<Text>().color = new Color(ComboColor.r, ComboColor.g, ComboColor.b, 1f);
        JudgeText.GetComponent<Text>().color = new Color(JudgeColor.r, JudgeColor.g, JudgeColor.b, 1f);
        //Text 색 초기화

        JudgeText.text = judge;
        if(judge != "MISS")
        {
            Combo += 1;
            ComboText.text = Combo.ToString();
        }
        StartCoroutine(uiManager.AlphaControl(ComboColor, result => ComboText.GetComponent<Text>().color = result, AlphaTime, 0f));
        StartCoroutine(uiManager.AlphaControl(JudgeColor, result => JudgeText.GetComponent<Text>().color = result, AlphaTime, 0f));
    }
    public void CurrentJudge(string judge)
    {
        switch(judge)
        {
            case "Miss":
                Combo = 0;
                ComboText.text = null;
                ChangeHP(-0.1f);
                ChangeJudgeText("MISS");
                break;
            case "Bad":
                ChangeScore(1);
                ChangeJudgeText("BAD");
                break;
            case "Great":
                ChangeScore(5);
                ChangeJudgeText("GREAT");
                break;
            case "Perfect":
                ChangeScore(10);
                ChangeHP(0.01f);
                ChangeJudgeText("PERFECT");
                break;
        }
    }
}
