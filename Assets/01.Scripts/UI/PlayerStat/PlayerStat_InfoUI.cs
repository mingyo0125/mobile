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
    private EquipItem_Icon[] _equippedSkills;  // �̰� �³�

    public override void UpdateUI()
    {

    }
}
