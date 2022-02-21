using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject PoolObject;
    private static GameObject NoteContainer;
    private Queue<Note> poolQueue = new Queue<Note>();

    private static ObjectPool instance;
    public static ObjectPool Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        NoteContainer = this.gameObject;
        Initialize(10);
    }


    private Note CreateNewObject()
    {
        var newObj = Instantiate(PoolObject, transform).GetComponent<Note>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }
    private void Initialize(int count)
    {
        for(int i = 0; i < count; i++)
        {
            poolQueue.Enqueue(CreateNewObject());
        }
    }
    public static Note GetObject()
    {
        if(Instance.poolQueue.Count > 0)
        {
            var obj = Instance.poolQueue.Dequeue();
            obj.transform.SetParent(NoteContainer.transform);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(NoteContainer.transform);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Note note)
    {
        note.gameObject.SetActive(false);
        note.transform.SetParent(Instance.transform);
        Instance.poolQueue.Enqueue(note);
    }

}
