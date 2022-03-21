using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    public UIManager uiManager;
    public Text ComboText;
    public Text JudgeText;
    public Text ScoreText;
    public Image HP_Fill;
    public float AlphaTime = 2f;
    private int Score { get; set; }
    private int Combo { get; set; }
/*    private void Update()
    {
        ChangeAlpha();
    }*/
    private void ChangeScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
    }
    private void ChangeHP(float hp)
    {
        HP_Fill.fillAmount += hp;
    }
    
    private void ChangeJudgeText(string judge)
    {
        ComboText.GetComponent<Text>().color = new Color(ComboText.GetComponent<Text>().color.r, ComboText.GetComponent<Text>().color.g, ComboText.GetComponent<Text>().color.b, 1f);
        JudgeText.GetComponent<Text>().color = new Color(JudgeText.GetComponent<Text>().color.r, JudgeText.GetComponent<Text>().color.g, JudgeText.GetComponent<Text>().color.b, 1f);
        //time = 0;
        //Text 색 초기화
        JudgeText.text = judge;
        if(judge != "MISS")
        {
            Combo += 1;
            ComboText.text = Combo.ToString();
        }
        StartCoroutine(uiManager.AlphaControl(ComboText.gameObject, AlphaTime, 0f));
        StartCoroutine(uiManager.AlphaControl(JudgeText.gameObject, AlphaTime, 0f));
    }
/*    private float time;
    private IEnumerator AlphaControl(GameObject text)
    {
        Color textColor = text.GetComponent<Text>().color;
        yield return new WaitForSeconds (0.05f);
        while (textColor.a > 0f)
        {
            time += Time.deltaTime / AlphaTime;
            textColor.a = Mathf.Lerp(1f, 0f, time);
            text.GetComponent<Text>().color = textColor;
            yield return null;
        }
    }*/
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
