using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnEquipItemButton : UI_Button, ISummonItemUI
{
    [SerializeField]
    private bool isDisableParent;

    [SerializeField]
    private bool isCloseTopUI;

    public SummonItemInfo ItemInfo { get; set; }

    private void Start()
    {
        if(isDisableParent)
        {
            CoroutineUtil.CallWaitForOneFrame(() => transform.parent.gameObject.SetActive(false));
        }
    }

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        ItemInfo = summonItem;
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();
        if (isCloseTopUI) { UIManager.Instance.RemoveTopUGUI(); }

        if (ItemInfo.ItemType == ItemType.Skill)
        {
            InventoryManager.Instance.UnEquipItem<SkillInfo>(ItemInfo.ItemType, ItemInfo.ItemId);
        }

        if (ItemInfo.ItemType == ItemType.Equipment)
        {
            InventoryManager.Instance.UnEquipItem<EquipmentInfo>(ItemInfo.ItemType, ItemInfo.ItemId);
        }
    }
}
