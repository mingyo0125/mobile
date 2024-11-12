using System;
using UnityEngine;

[Serializable]
public class SkillInfo : ISummonItem
{
    [field: SerializeField]
    public string SkillName { get; private set; }
    [field: SerializeField]
    public string Description { get; private set; }
    [field: SerializeField]
    public float Cooldown { get; private set; }
    [field: SerializeField]
    public float DamagePercent { get; private set; }

    [field: SerializeField]
    public FeedbackEffect HitFeedbackEffect { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [field: SerializeField]
    public float SummonProbability { get; private set; }

    [field: SerializeField]
    public int ElementsCount { get; private set; }

    public SkillInfo(SkillInfo skillInfo)
    {
        this.SkillName = skillInfo.SkillName;
        this.Description = skillInfo.Description;
        this.Cooldown = skillInfo.Cooldown;
        this.DamagePercent = skillInfo.DamagePercent;

        this.Icon = skillInfo.Icon;

        this.SummonProbability = skillInfo.SummonProbability;
    }

    #region

    public float GetSummonProbability()
    {
        Debug.Log("등급에 따라 다르게 하셈");
        return SummonProbability;
    }

    public Sprite GetSummonIcon()
    {
        return Icon;
    }

    public void GetItem()
    {
        SkillManager.Instance.AddSkill(SkillName);
    }

    public int GetElementsCount()
    {
        return ElementsCount;
    }

    public void AddElementsCount()
    {
        ElementsCount++;
    }

    #endregion

}