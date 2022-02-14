using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private Poolable poolObj;
    [SerializeField]
    private int NoteCount;

    private Stack<Poolable> poolStack = new Stack<Poolable>();

    private void Start()
    {
        NoteCreate();
    }

    public void NoteCreate()
    {
        for(int i = 0; i < NoteCount; i++)
        {
            Poolable noteObj = Instantiate(poolObj, this.gameObject.transform);
            noteObj.Create(this);
            poolStack.Push(noteObj);
        }
    }

    public GameObject Pop()
    {
        Poolable obj = poolStack.Pop();
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }

    public void Push(Poolable obj)
    {
        obj.gameObject.SetActive(false);
        poolStack.Push(obj);
    }
}
