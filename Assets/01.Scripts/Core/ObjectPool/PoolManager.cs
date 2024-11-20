using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoSingleTon<PoolManager>
{
    [field: SerializeField]
    public PoolObjectsSO PoolObjSO { get; private set; }

    private Dictionary<string, ObjectPool<PoolableMono>> _poolObjects = new();

    private void Awake()
    {
        PoolObjSO.UpdatePoolObjects();

        foreach(PoolObjectsInfo poolObjectInfo in PoolObjSO.PoolObjects)
        {
            PoolableMono poolObject = poolObjectInfo.PoolObject;
            int poolCount = poolObjectInfo.PoolCount;

            ObjectPool<PoolableMono> objectPool = new ObjectPool<PoolableMono>(poolObject, poolCount, transform);

            _poolObjects.Add(poolObject.name, objectPool);

            if(poolObjectInfo.IsStartCreate)
            {
                PoolableMono spawnedObj = CreateObject(poolObject.name);
                CoroutineUtil.CallWaitForOneFrame(() => DestroyObject(spawnedObj));
            }
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
}
