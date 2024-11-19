using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SummonItemInfo: ISummonItem
{
    [field: SerializeField]
    public string ItemName { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [field: SerializeField]
    public float SummonProbability { get; private set; }

    [field: SerializeField]
    public int ItemLevel { get; private set; }


    // 나중에 직렬화 지우셈 later
    [field: SerializeField]
    public int ElementsCount { get; private set; }

    public void AddElementsCount()
    {
        ElementsCount++;
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
        SkillManager.Instance.AddSkill(ItemName);
    }

    public int GetElementsCount()
    {
        return ElementsCount;
    }

    public string GetName()
    {
        return ItemName;
    }

    public void EquipSummonItem()
    {
        SkillManager.Instance.EquipSkill(ItemName);
    }

    public int GetItemLevel()
    {
        return ItemLevel;
    }

    #endregion ISummonItem
}
