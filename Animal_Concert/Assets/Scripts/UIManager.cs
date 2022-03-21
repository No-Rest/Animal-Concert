using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public IEnumerator AlphaControl(GameObject color, float destoryTime, float time)
    {
        Color textColor = color.GetComponent<Text>().color; 
        //yield return new WaitForSeconds(0.05f);
        while (textColor.a > 0f)
        {

            time += Time.deltaTime / destoryTime;
            textColor.a = Mathf.Lerp(1f, 0f, time);
            color.GetComponent<Text>().color = textColor;
            Debug.Log(color);
            yield return null;
        }
    }
}
