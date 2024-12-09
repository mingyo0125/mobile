using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonItem_Inventory : UI_Component
{
    [SerializeField]
    private EquippingSummonItemUI _equippingSkillUI;

    private SummonItemIconFactory _summonItem_IconFactory;

    private void Awake()
    {
        _summonItem_IconFactory = FindAnyObjectByType<SummonItemIconFactory>();
    }

    private void Start()
    {
        Signalhub.OnSelectChnageSkillEvent += GenerateEquippingSkillUI;
    }

    private void GenerateEquippingSkillUI(SkillInfo skillInfo)
    {
        _equippingSkillUI.SetItemInfo(_summonItem_IconFactory.GetInventoryItemIcon(skillInfo));
        _equippingSkillUI.UpdateUI();
    }

    public override void UpdateUI()
    {
    }
}
