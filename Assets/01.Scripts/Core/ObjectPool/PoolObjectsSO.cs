using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PoolObjectsInfo
{
    [field:SerializeField]
    public PoolableMono PoolObject { get; private set; }
    [field: SerializeField]
    public int PoolCount { get; private set; }
}

[CreateAssetMenu(menuName = "SO/PoolObjects")]
public class PoolObjectsSO : ScriptableObject
{
    public List<PoolObjectsInfo> PoolObjects { get; private set; }
    [field: SerializeField]
    public List<PoolObjectsInfo> Entitys { get; private set; }

    [field: SerializeField]
    public List<PoolObjectsInfo> Items { get; private set; }

    [field: SerializeField]
    public List<PoolObjectsInfo> ETC { get; private set; }

    public void UpdatePoolObjects()
    {
        PoolObjects.Clear();
        PoolObjects.AddRange(Entitys);
        PoolObjects.AddRange(Items);
        PoolObjects.AddRange(ETC);
    }
}
