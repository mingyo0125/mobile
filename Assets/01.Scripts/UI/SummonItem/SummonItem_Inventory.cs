using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonItem_Inventory<T> : UI_Component where T : SummonItemInfo
{
    [SerializeField]
    private EquippingSummonItemUI _equippingSkillUI;

    [SerializeField]
    private SummonItemIconFactory<T> _summonItem_IconFactory;

    protected void GenerateEquippingSkillUI(T skillInfo)
    {
        _equippingSkillUI.SetItemInfo(_summonItem_IconFactory.GetInventoryItemIcon(skillInfo));
        _equippingSkillUI.UpdateUI();
    }

    public override void UpdateUI()
    {
    }
}
