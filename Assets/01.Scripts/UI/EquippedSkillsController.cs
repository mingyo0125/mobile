using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedSkillsController : MonoBehaviour
{
    private Dictionary<SummonItemInfo, EquipItem_Icon> _equippedSkill_Icons = new Dictionary<SummonItemInfo, EquipItem_Icon>();
    private List<EquipItem_Icon> _summonItemIcons = new List<EquipItem_Icon>();

    private const string EquipItem_Icon = "EquipItem_Icon";

    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            EquipItem_Icon equipItem_Icon = UIManager.Instance.GenerateUI(EquipItem_Icon,
                                                                          transform,
                                                                          UIGenerateType.NONE,
                                                                          UIGenerateSortType.NONE) as EquipItem_Icon;

            _summonItemIcons.Add(equipItem_Icon);
        }
    }

    public void EquippedSkill(SummonItemInfo summonItemInfo)
    {
        EquipItem_Icon epuippedIcon = GetEmptyButton();

        epuippedIcon.SetSummonItem(summonItemInfo);

        _equippedSkill_Icons.Add(summonItemInfo, epuippedIcon);
    }

    private EquipItem_Icon GetEmptyButton()
    {
        foreach (EquipItem_Icon button in _summonItemIcons)
        {
            if (!button.IsUsingButton)
            {
                return button;
            }
        }
        return null;
    }
}
