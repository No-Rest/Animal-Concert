using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMoving : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject SelectionBox;
    
    public GameObject SelectionTarget;
    
    public GameObject Button;
    
    public GameObject ButtonTarget;

    public float SelectionSpeed;
    public float ButtonSpeed;

    private bool isSelection;
    private bool isButton;
    private int loopNum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if(isSelection && isButton)
            //SceneManager.LoadScene("Loading");
    }

    public void StartMoving()
    {
        StartCoroutine(SelectionMoving());
        StartCoroutine(ButtonMoving());
    }

    public IEnumerator SelectionMoving()
    {

        while (true)
        {
            //SelectionBox.transform.position = Vector3.Lerp(SelectionBox.transform.position, SelectionTarget.transform.position, Time.deltaTime*SelectionSpeed);
            SelectionBox.transform.position = Vector3.MoveTowards(SelectionBox.transform.position, SelectionTarget.transform.position, Time.deltaTime * SelectionSpeed); 


            if (Mathf.Abs(SelectionBox.transform.position.y - SelectionTarget.transform.position.y) < 20)
            {
                Debug.Log("끝");
                isSelection = true;
                break;
            }
            yield return null;
        }
        yield return null;
    }
    
    public IEnumerator ButtonMoving()
    {
        //yield return new WaitForSeconds(1f);
        
        while (true)
        {
            //Button.transform.position = Vector3.Lerp(Button.transform.position, new Vector3(Button.transform.position.x, ButtonTarget.transform.position.y, Button.transform.position.z), Time.deltaTime * ButtonSpeed);
            Button.transform.position = Vector3.MoveTowards( Button.transform.position,  ButtonTarget.transform.position, Time.deltaTime *  ButtonSpeed); 
            if (Mathf.Abs(Button.transform.position.y - ButtonTarget.transform.position.y) < 20)
            {
                Debug.Log("끝");
                isButton = true;
                break;
            }
            yield return null;
        }
        
        yield return null;
    }
    
    
    
}
