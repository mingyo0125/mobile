using System;
using UnityEngine;

[Serializable]
public class SkillInfo : ISummonItem
{
    [field: SerializeField]
    public string Description { get; private set; }
    [field: SerializeField]
    public float Cooldown { get; private set; }
    [field: SerializeField]
    public float DamagePercent { get; private set; }

    [field: SerializeField]
    public FeedbackEffect HitFeedbackEffect { get; private set; }

    [field: SerializeField]
    public SummonItemInfo SummonItemInfo { get; private set; }

    public SkillInfo(SkillInfo skillInfo)
    {
        this.Description = skillInfo.Description;
        this.Cooldown = skillInfo.Cooldown;
        this.DamagePercent = skillInfo.DamagePercent;

        this.SummonItemInfo = skillInfo.SummonItemInfo;
    }

    #region

    public float GetSummonProbability()
    {
        Debug.Log("등급에 따라 다르게 하셈");
        return SummonItemInfo.SummonProbability;
    }

    public Sprite GetSummonIcon()
    {
        return SummonItemInfo.Icon;
    }

    public void GetItem()
    {
        SkillManager.Instance.AddSkill(SummonItemInfo.ItemName);
    }

    public int GetElementsCount()
    {
        return SummonItemInfo.ElementsCount;
    }

    public void AddElementsCount()
    {
        SummonItemInfo.AddElementsCount();
    }

    public string GetName()
    {
        return SummonItemInfo.ItemName;
    }

    public void EquipSummonItem()
    {
        SkillManager.Instance.EquipSkill(SummonItemInfo.ItemName);
    }

    #endregion

}