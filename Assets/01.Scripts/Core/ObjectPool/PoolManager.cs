using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    private PoolObjectsSO _poolObjectsSO;

    public Dictionary<string, ObjectPool<PoolableMono>> PoolObjects { get; private set; } = new();

    private void Awake()
    {
        _poolObjectsSO = new PoolObjectsSO();
        _poolObjectsSO.UpdatePoolObjects();

        foreach(PoolObjectsInfo poolObject in _poolObjectsSO.PoolObjects)
        {
            PoolableMono PoolObject = poolObject.PoolObject;
            int poolCount = poolObject.PoolCount;

            PoolObjects.Add(PoolObject.name, new ObjectPool<PoolableMono>(PoolObject, poolCount, transform));
        }
    }

    public void CreateObject(string name)
    {
        PoolObjects[name].Create();
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
