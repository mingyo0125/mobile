using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EquippingSkillUI : UI_Component
{
    [SerializeField]
    private GameObject _allSkillsUI;

    [SerializeField]
    private Transform _equipSkillButtonTrm;

    private const string inventoryItemIcon = "Inventory_ItemIcon";

    public override void UpdateUI()
    {
        _allSkillsUI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void SetSkillInfo(InventoryItem_Icon inventoryItem_Icon)
    {
        inventoryItem_Icon.transform.SetParent(_equipSkillButtonTrm);
    }

    public void SetInfo()
    {

    }

}
