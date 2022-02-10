//***************************************
// EDITOR : CHA Hee Gyoung
// LAST EDITED DATE : 2022.02.09
// Script Purpose : Main UI [Drag Function]
//***************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Text text1;
    public Vector2 DirectionToMove;
    public MusicInfo musicInfo;
    public bool isStart;
    public bool isDone = true;
    public float speed;

    
    public GameObject panel0;

    private Vector3 Target;
    private Vector2 mouseOffset;

    void Start()
    {
        Target = transform.position;
    }
    
    void Update()
    {
        if(!isDone)
            Moving();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseOffset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        
        //Debug.Log(string.Format("{0}",mouseOffset.x) + String.Format("{0}",mouseOffset.y));
    }

    public void OnDrag(PointerEventData eventData)
    {
        float x = transform.position.x;
        //transform.position = eventData.position + mouseOffset;
        x = eventData.position.x + mouseOffset.x;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        //Debug.Log(transform.position);
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("드래그 중지(오브젝트 안에서 마우스 뗌)");
        //SelectNumber();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("드래그 중지(오브젝트 안이든 밖이든)");
        SelectNumber();
    }
    

    void SelectNumber()//자식객체의 포지션 가져오고, 가운데에 위치시킬 객체 정하고, 뮤직인포의 셀렉트넘버 바꿔주기, 그리고 가운데로 위치시키기
    {
        Vector3 value;
        for (int i = 0; i < transform.childCount; i++)
        {
            value = transform.GetChild(i).position;
            if (Mathf.Abs(1440 - value.x) < 450)
            {
                musicInfo.SelectedNumber = i;
                break;
            }
        }

        float minus = 1440 - transform.GetChild(musicInfo.SelectedNumber).position.x;

        Target = new Vector3(transform.position.x + minus, transform.position.y, transform.position.z);
        

        isDone = false;
    }

    void Moving()
    {
        transform.position = Vector3.Lerp(transform.position, Target, Time.deltaTime * speed);
        if (transform.position.x - Target.x < 0.5)
        {
            isDone = true;
        }
    }


    
}
