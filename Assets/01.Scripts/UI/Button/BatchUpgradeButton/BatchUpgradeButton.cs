using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatchUpgradeButton<T> : UI_Button where T : SummonItemInfo
{
    [SerializeField]
    private GameObject CanUpgradeIcon_Image;

    private void Start()
    {
        foreach (T skillInfo in SummonItemManager<T>.Instance.Items.Values)
        {
            if(skillInfo is T)
            {
                skillInfo.OnItemGetEvent += OnCanUpgradeIcon_Image;
                skillInfo.OnItemLevelUpEvent += OnCanUpgradeIcon_Image;
            }
        }
    }

    private void OnCanUpgradeIcon_Image()
    {
        bool canUpgrade = false;
        foreach (T skillInfo in SummonItemManager<T>.Instance.Items.Values)
        {
            if (skillInfo is T)
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

        foreach (T skillInfo in SummonItemManager<T>.Instance.Items.Values)
        {
            if (skillInfo is T)
            {
                while (skillInfo.CanUpgrade)
                {
                    skillInfo.ItemLevelUp();
                }
            }
        }
    }

}
