using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Inventory : UI_Component
{
    [SerializeField]
    private EquippingSkillUI _equippingSkillUI;

    private Skill_IconFactory _skill_IconFactory;

    private void Awake()
    {
        _skill_IconFactory = FindAnyObjectByType<Skill_IconFactory>();
    }

    private void Start()
    {
        Signalhub.OnSkillChangingEvent += GenerateEquippingSkillUI;
    }

    private void GenerateEquippingSkillUI(SkillInfo skillInfo)
    {
        _equippingSkillUI.SetSkillInfo(_skill_IconFactory.GetInventoryItemIcon(skillInfo));
        _equippingSkillUI.UpdateUI();
    }

    public override void UpdateUI()
    {
    }

}
