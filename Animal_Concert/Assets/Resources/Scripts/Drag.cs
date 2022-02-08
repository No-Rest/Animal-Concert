using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Text text1;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin!");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("드래그중");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("오브젝트 안에서 드래그 중지");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 중지(오브젝트 안이든 밖이든)");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            text1.text = "터치됨!";

        }
    }
}
