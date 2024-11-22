using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Inventory : UI_Component
{
    [SerializeField]
    private EquippingSkillUI _equippingSkillUI;

    private void Start()
    {
        Signalhub.OnSkillChangingEvent += GenerateEquippingSkillUI;
    }

    private void GenerateEquippingSkillUI()
    {
        Debug.Log("A");
        _equippingSkillUI.UpdateUI();
    }

    public override void UpdateUI()
    {
    }

}
