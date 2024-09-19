using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool<T> where T : PoolableMono
{
    private Queue<T> _poolObjs = new Queue<T>();
    private T _poolPrefab;
    private Transform _parentTrm;

    public ObjectPool(T poolprefab, int poolcount, Transform parentTrm)
    {
        _poolPrefab = poolprefab;
        _parentTrm = parentTrm;
        poolprefab.gameObject.SetActive(false);

        for (int i = 0; i < poolcount; i++)
        {
            Instantiate();
        }
    }

    public PoolableMono Create()
    {
        if (_poolObjs.Count <= 0)
        {
            Instantiate();
        }

        T poolObj = _poolObjs.Dequeue();
        poolObj.transform.SetParent(_parentTrm);
        poolObj.gameObject.SetActive(true);
        return poolObj;
    }

    public void Destroy(T obj)
    {
        obj.transform.position = _parentTrm.position;
        obj.transform.rotation = Quaternion.identity;
        obj.gameObject.SetActive(false);
        _poolObjs.Enqueue(obj);
    }

    private T Instantiate()
    {
        T obj = GameObject.Instantiate(_poolPrefab, _parentTrm.position, Quaternion.identity);
        obj.transform.SetParent(_parentTrm);
        obj.name = _poolPrefab.name;
        _poolObjs.Enqueue(obj);

        return obj;
    }
}
