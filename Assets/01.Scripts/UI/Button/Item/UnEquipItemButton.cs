using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnEquipItemButton : UI_Button
{
    private SummonItemInfo _item;

    [SerializeField]
    private bool isDisableParent;

    private void Start()
    {
        if(isDisableParent)
        {
            CoroutineUtil.CallWaitForOneFrame(() => transform.parent.gameObject.SetActive(false));
        }
    }

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        _item = summonItem;
    }

    protected override void ButtonEvent()
    {
        InventoryManager.Instance.UnEquipItem(_item.ItemType, _item.ItemId);
    }
}
