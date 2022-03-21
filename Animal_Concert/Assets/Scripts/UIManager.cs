using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public IEnumerator AlphaControl(Color currentColor, Action<Color> color, float destoryTime, float time) //���İ����� destoryTime �ð� ���� ���� ��������
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
}
