using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_Inventory : SummonItem_Inventory
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
            _equipItem_Icon.ReSetSummonItem();
        }

        _equipItem_Icon.SetSummonItem(summonItemInfo);
    }
}
