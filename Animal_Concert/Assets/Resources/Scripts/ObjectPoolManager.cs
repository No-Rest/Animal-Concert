using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public ObjectPool pool;
    private static ObjectPoolManager instance;
    public static ObjectPoolManager Instance
    {
        get
        {
            return Instance;
        }
    }
    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
