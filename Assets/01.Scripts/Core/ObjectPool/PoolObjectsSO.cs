using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnEntityTypes
{
    ETC,
    Enemies,
    Items,
    Coins,
    UI,
}

[Serializable]
public struct PoolObjectsInfo
{
    [field: SerializeField]
    public PoolableMono PoolObject { get; private set; }
    [field: SerializeField]
    public int PoolCount { get; private set; }
}

[CreateAssetMenu(menuName = "SO/PoolObjects")]
public class PoolObjectsSO : ScriptableObject
{
    public List<PoolObjectsInfo> PoolObjects { get; private set; } = new List<PoolObjectsInfo>();
    [field: SerializeField]
    public List<PoolObjectsInfo> Enemies { get; private set; } = new();

    [field: SerializeField]
    public List<PoolObjectsInfo> Items { get; private set; } = new();

    [field: SerializeField]
    public List<PoolObjectsInfo> Coins { get; private set; } = new();

    [field: SerializeField]
    public List<PoolObjectsInfo> ETC { get; private set; } = new();

    [field: SerializeField]
    public List<PoolObjectsInfo> UI { get; private set; } = new();

    public void UpdatePoolObjects()
    {
        PoolObjects.Clear();
        PoolObjects.AddRange(Enemies);
        PoolObjects.AddRange(Items);
        PoolObjects.AddRange(ETC);
        PoolObjects.AddRange(Coins);
        PoolObjects.AddRange(UI);
    }
}
