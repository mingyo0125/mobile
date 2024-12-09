using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingSummonItemUI : UI_Component
{
    [SerializeField]
    private GameObject _allSummonItemsUI;

    [SerializeField]
    private Transform _equipSummonItemButtonTrm;

    private const string inventoryItemIcon = "Inventory_ItemIcon";

    private InventoryItem_Icon _equippingItem_Icon;
    private Transform _prevequippingItemParentTrm;
    
    public override void UpdateUI()
    {
        _allSummonItemsUI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void SetItemInfo(InventoryItem_Icon inventoryItem_Icon)
    {
        _equippingItem_Icon = inventoryItem_Icon;
        _prevequippingItemParentTrm = inventoryItem_Icon.transform.parent;

        _equippingItem_Icon.ChangeParent(_equipSummonItemButtonTrm);
    }

    public void CloseEquippingSkillUI()
    {
        _equippingItem_Icon.ChangeParent(_prevequippingItemParentTrm);
        _equippingItem_Icon = null;

        _allSummonItemsUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
