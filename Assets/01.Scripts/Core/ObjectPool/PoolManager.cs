using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; // Temp SingleTon

    [field: SerializeField]
    public PoolObjectsSO PoolObjSO { get; private set; }

    private Dictionary<string, ObjectPool<PoolableMono>> _poolObjects = new();

    private void Awake()
    {
        if (Instance == null)  // Temp SingleTon
        {
            Instance = this;
        }

        PoolObjSO.UpdatePoolObjects();

        foreach(PoolObjectsInfo poolObjectInfo in PoolObjSO.PoolObjects)
        {
            PoolableMono poolObject = poolObjectInfo.PoolObject;
            int poolCount = poolObjectInfo.PoolCount;

            ObjectPool<PoolableMono> objectPool = new ObjectPool<PoolableMono>(poolObject, poolCount, transform);

            _poolObjects.Add(poolObject.name, objectPool);
        }
    }

    public PoolableMono CreateObject(string name)
    {
        return _poolObjects[name].Create();
    }

    public void DestroyObject(PoolableMono obj)
    {
        try
        {
            _poolObjects[obj.name].Destroy(obj);
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
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
