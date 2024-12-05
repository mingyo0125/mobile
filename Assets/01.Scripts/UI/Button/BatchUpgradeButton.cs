using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatchUpgradeButton : UI_Button
{
    [SerializeField]
    private GameObject CanUpgradeIcon_Image;

    private void Start()
    {
        foreach (SummonItemInfo skillInfo in SummonItemManager<SkillInfo>.Instance.Items.Values)
        {
            if(skillInfo is SkillInfo)
            {
                skillInfo.OnItemGetEvent += OnCanUpgradeIcon_Image;
                skillInfo.OnItemLevelUpEvent += OnCanUpgradeIcon_Image;
            }
        }
    }

    private void OnCanUpgradeIcon_Image()
    {
        bool canUpgrade = false;
        foreach (SummonItemInfo skillInfo in SummonItemManager<SkillInfo>.Instance.Items.Values)
        {
            if (skillInfo is SkillInfo)
            {
                if (skillInfo.CanUpgrade)
                {
                    canUpgrade = true;
                    break;
                }
            }
        }

        CanUpgradeIcon_Image.SetActive(canUpgrade);
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        foreach (SummonItemInfo skillInfo in SummonItemManager<SkillInfo>.Instance.Items.Values)
        {
            if (skillInfo is SkillInfo)
            {
                while (skillInfo.CanUpgrade)
                {
                    skillInfo.ItemLevelUp();
                }
            }
        }
    }

}
