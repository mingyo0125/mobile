using System;
using UnityEngine;

public interface ISavable
{
    public string FilePath { get; }
}

public interface IData
{
    public string FilePath { get; }
}

[Serializable]
public class PlayerData : IData
{
    public PlayerStat PlayerStats;

    public PlayerData(PlayerStat savable)
    {
        PlayerStats = new PlayerStat(savable);
    }

    public string FilePath => PlayerStats.FilePath;
}

[Serializable]
public class SummonItemData<T> : IData where T : SummonItemInfo
{
    public T ItemInfo;

    public SummonItemData(T savable)
    {
        ItemInfo = Activator.CreateInstance(typeof(T), savable) as T;
    }

    public string FilePath => ItemInfo.FilePath;
}
