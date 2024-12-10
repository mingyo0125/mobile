using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStat_InfoUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _statText;

    [SerializeField]
    private EquipItem_Icon _equippedItem_Icon;

    [SerializeField]
    private EquipItem_Icon[] _equippedSkills;

    private StringBuilder _stringBuilder;

    private void Awake()
    {
        _stringBuilder = new StringBuilder();
    }

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
        UpdateStatDescription();
    }

    private void UpdateStatDescription()
    {
        _statText.SetText(BuildStatString());
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

    private string BuildStatString()
    {
        _stringBuilder.Clear();

        PlayerStat playerStat = GameManager.Instance.GetPlayerStat();

        _stringBuilder.AppendLine($"���ݷ�: {playerStat.Damage.Value:F1}");
        _stringBuilder.AppendLine($"ü��: {playerStat.MaxHP.Value:F1}");
        _stringBuilder.AppendLine($"�ӵ�: {playerStat.Speed.Value:F1}");
        _stringBuilder.AppendLine($"ġ��Ÿ Ȯ��: {playerStat.CriticalProbability.Value:F1}%");
        _stringBuilder.AppendLine($"ġ��Ÿ ������ ����: {playerStat.CriticalDamageIncreasePercent.Value:F1}%");
        _stringBuilder.AppendLine($"���Ľ�: {playerStat.ResistancePercent.Value:F1}%");

        return _stringBuilder.ToString();
    }
}
