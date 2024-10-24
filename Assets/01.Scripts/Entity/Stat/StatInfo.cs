using System;
using UnityEngine;

[Serializable]
public struct StatInfo
{
    public int Level;
    public float Value;

    [field: SerializeField]
    public StatUIInfo StatUIInfo { get; private set; }

    public StatInfo(int level, float value, StatUIInfo statUIInfo)
    {
        this.Level = level;
        this.Value = value;
        this.StatUIInfo = statUIInfo;
    }
}

[Serializable]
public struct StatUIInfo
{
    public string Name;
    public Sprite StatSprite;

    public StatUIInfo(string name, Sprite statSprite)
    {
        this.Name = name;
        this.StatSprite = statSprite;
    }
}
