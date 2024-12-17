using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavable
{
    public string FilePath { get; }

    public T GetSavableData<T>() where T : class, ISavable;
}

public interface IData
{
    public string FilePath { get; }
}

[System.Serializable]
public class PlayerData : IData
{
    public PlayerStat PlayerStats;

    public PlayerData(PlayerStat savable)
    {
        PlayerStats = new PlayerStat(savable);
    }

    public string FilePath => PlayerStats.FilePath;
}
