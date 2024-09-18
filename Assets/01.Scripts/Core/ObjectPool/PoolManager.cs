using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; // Temp SingleTon

    public PoolObjectsSO PoolObjSO { get; private set; }

    public Dictionary<string, ObjectPool<PoolableMono>> PoolObjects { get; private set; } = new();

    private void Awake()
    {
        if (Instance == null)  // Temp SingleTon
        {
            Instance = this;
        }

        PoolObjSO = new PoolObjectsSO();
        PoolObjSO.UpdatePoolObjects();

        foreach(PoolObjectsInfo poolObject in PoolObjSO.PoolObjects)
        {
            PoolableMono PoolObject = poolObject.PoolObject;
            int poolCount = poolObject.PoolCount;

            ObjectPool<PoolableMono> objectPool = new ObjectPool<PoolableMono>(PoolObject, poolCount, transform);

            PoolObjects.Add(PoolObject.name, objectPool);
        }
    }

    public PoolableMono CreateObject(string name)
    {
        return PoolObjects[name].Create();
    }

    public void DestroyObject(PoolableMono obj)
    {
        PoolObjects[name].Destroy(obj);
    }

    //private void Awake()
    //{
    //    _pool = new ObjectPool();
    //}

    //public PoolableMono Create(string name)
    //{
    //    return _pool.PoolObjects[name].Dequeue();
    //}

    //public void Destroy(PoolableMono poolObj)
    //{
    //    poolObj.gameObject.SetActive(false);
    //    poolObj.transform.parent = transform;

    //    _pool.PoolObjects[poolObj]  
    //}
}
