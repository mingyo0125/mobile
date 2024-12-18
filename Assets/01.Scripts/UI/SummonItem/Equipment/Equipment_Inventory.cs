using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_Inventory : SummonItem_Inventory<EquipmentInfo>
{
    [SerializeField]
    private Transform EquippedItemsTrm;

    EquipItem_Icon _equipItem_Icon;

    private void Start()
    {
        CoroutineUtil.CallWaitForOneFrame(() => _equipItem_Icon = EquippedItemsTrm.GetChild(0).GetComponent<EquipItem_Icon>());
    }

    public void EquipItem(SummonItemInfo summonItemInfo)
    {
        if(_equipItem_Icon.IsEquipped)
        {
            InventoryManager.Instance.UnEquipItem(_equipItem_Icon.ItemInfo.ItemType, _equipItem_Icon.ItemInfo.ItemId);

            _equipItem_Icon.ReSetSummonItem();
        }

        _equipItem_Icon.SetSummonItem(summonItemInfo);

    }

    public void UnEquipItem()
    {
        if (!_equipItem_Icon.IsEquipped)
        {
            Debug.LogError($"Equipment is null");
            return;
        }

        _equipItem_Icon.ReSetSummonItem();
    }
}
