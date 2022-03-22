using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CountText
{
    public Text MissText;
    public Text BadText;
    public Text GoodText;
    public Text ExcellentText;
    public Text MaxComboText;
    public Text TotalScoreText;

    public CountText(Text missText, Text badText, Text goodText, Text excellentText, Text maxComboText, Text totalScoreText)
    {
        MissText = missText;
        BadText = badText;
        GoodText = goodText;
        ExcellentText = excellentText;
        MaxComboText = maxComboText;
        TotalScoreText = totalScoreText;
    }
}
public class UIManager : MonoBehaviour
{
    public CountText count;
    public GameManager gameManager;
    public IEnumerator AlphaControl(Color currentColor, Action<Color> color, float destoryTime, float time) //알파값조절 destoryTime 시간 까지 점점 투명해짐
    {
        Color textColor = currentColor; 
        yield return new WaitForSeconds(0.02f);
        while (textColor.a > 0f)
        {
            time += Time.deltaTime / destoryTime;
            textColor.a = Mathf.Lerp(1f, 0f, time);
            color(textColor);
            yield return null;
        }
    }
    public void PlayResult()
    {
        count.MissText.text = gameManager.judgeCount.MissCount.ToString();
        count.BadText.text = gameManager.judgeCount.BadCount.ToString();
        count.GoodText.text = gameManager.judgeCount.GoodCount.ToString();
        count.ExcellentText.text = gameManager.judgeCount.ExcellentCount.ToString();
        count.MaxComboText.text = gameManager.judgeCount.MaxComboCount.ToString();
        count.TotalScoreText.text = gameManager.judgeCount.TotalScoreCount.ToString();


    }
    public void TryAgain()
    {

    }


}
