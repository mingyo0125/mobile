using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonItem_Inventory : UI_Component
{
    [SerializeField]
    private EquippingSummonItemUI _equippingSkillUI;

    [SerializeField]
    private SummonItemIconFactory _summonItem_IconFactory;

    protected void GenerateEquippingSkillUI(SummonItemInfo skillInfo)
    {
        _equippingSkillUI.SetItemInfo(_summonItem_IconFactory.GetInventoryItemIcon(skillInfo));
        _equippingSkillUI.UpdateUI();
    }

    public override void UpdateUI()
    {
    }
}
