using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ad;
    public float speed = 1;
    public bool isStart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(transform.position.x);
        
        transform.position = Vector3.Lerp(transform.position, ad.transform.position, Time.deltaTime * speed);
        if (!isStart)
        {
            
            Debug.Log("시작!");
            isStart = true;
        }
        
    }
}
