using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStat_InfoUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _statText;

    [SerializeField]
    private EquipItem_Icon _equippedItem_Icon;

    [SerializeField]
    private EquipItem_Icon[] _equippedSkills;  // 이게 맞나

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpdateUI();
        }
    }

    public override void UpdateUI()
    {
        UpdateEquippedEquipment();
        UpdateEquippedSkill();
    }

    private void UpdateEquippedEquipment()
    {
        EquipmentManager equipmentManager = EquipmentManager.Instance as EquipmentManager;
        EquipmentInfo equipmentInfo = equipmentManager.GetCurEquipmentInfo();
        if (equipmentInfo != null)
        {
            _equippedItem_Icon.SetSummonItem(equipmentInfo);
        }
    }

    private void UpdateEquippedSkill()
    {
        if (!InventoryManager.Instance.EquippedInventory.TryGetValue(ItemType.Skill, out var values))
        {
            return;
        }

        int idx = 0;
        foreach (var skill in values.Values)
        {
            _equippedSkills[idx].SetSummonItem(skill);
            idx++;

            Debug.Log(skill.ItemName);
        }

        Debug.Log(idx);
        
    }
}
