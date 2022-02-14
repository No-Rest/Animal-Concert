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
    
    public Vector2 DirectionToMove;
    public MusicInfo musicInfo;
    public bool isStart;
    public bool isDone = true;
    public float speed;
    public int StartPanel;//시작할때 크기 키울 시작패널


    private float minus;
    private RectTransform rectTran;
    private Vector3 Target;
    private Vector2 mouseOffset;

    void Start()
    {
        musicInfo.SelectedNumber = StartPanel;
        rectTran = transform.GetChild(musicInfo.SelectedNumber).GetComponent<RectTransform>();
        rectTran.sizeDelta = new Vector2(730, 1058);

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
        isDone = true; //드래그하는 중 움직이지 않게 하기 위해
        float x = transform.position.x;
        //transform.position = eventData.position + mouseOffset;
        x = eventData.position.x + mouseOffset.x;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        //Debug.Log(transform.position);
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("드래그 중지(오브젝트 안에서 마우스 뗌)");
        SelectNumber();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("드래그 중지(오브젝트 안이든 밖이든)");
        if (transform.position.x > 1600)
        {
            OriginalPanelSize(musicInfo.SelectedNumber);
            musicInfo.SelectedNumber = 0;
            minus = 0 - transform.GetChild(musicInfo.SelectedNumber).position.x; 
            Target = new Vector3(transform.position.x + minus, transform.position.y, transform.position.z);
            isDone = false;
        }
        
        else if (transform.position.x < -800)
        {
            OriginalPanelSize(musicInfo.SelectedNumber);
            musicInfo.SelectedNumber = 3;
            minus = 0 - transform.GetChild(musicInfo.SelectedNumber).position.x; 
            Target = new Vector3(transform.position.x + minus, transform.position.y, transform.position.z);
            isDone = false;
        }
        
        else SelectNumber();
    }


    void ExtendPanelSize(int x)
    {
        rectTran = transform.GetChild(x).GetComponent<RectTransform>();
        rectTran.sizeDelta = new Vector2(730, 1058);
    }
    void OriginalPanelSize(int x)
    {
        rectTran = transform.GetChild(x).GetComponent<RectTransform>();
        rectTran.sizeDelta = new Vector2(696, 1008);
    }
    void SelectNumber()//자식객체의 포지션 가져오고, 가운데에 위치시킬 객체 정하고, 뮤직인포의 셀렉트넘버 바꿔주기, 그리고 가운데로 위치시키기
    {
        OriginalPanelSize(musicInfo.SelectedNumber);
        Vector3 value;
        for (int i = 0; i < transform.childCount; i++)
        {
            value = transform.GetChild(i).position;
            if (Mathf.Abs(0 - value.x) < 400)
            {
                musicInfo.SelectedNumber = i;
                break;
            }
        }
        //원점과 가운데로 위치시키기 위해 변동시켜줄 값. 원점보다 오른쪽에 있다면 왼쪽으로 가야하기 때문에 - 시켜준다.
        minus = 0 - transform.GetChild(musicInfo.SelectedNumber).position.x; 
        Target = new Vector3(transform.position.x + minus, transform.position.y, transform.position.z);
        isDone = false;
    }

    void Moving()
    {
        
        ExtendPanelSize(musicInfo.SelectedNumber);
        //Debug.Log(transform.position.x + minus);
        
        transform.position = Vector3.Lerp(transform.position, Target, Time.deltaTime * speed);
        
        if (Mathf.Abs(transform.position.x - Target.x) < 0.5)
        {
            isDone = true;
        }
    }


    
}
