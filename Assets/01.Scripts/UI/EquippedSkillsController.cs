using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedSkillsController : MonoBehaviour
{
    private Dictionary<SummonItemInfo, EquipItem_Icon> _equippedSkill_Icons = new Dictionary<SummonItemInfo, EquipItem_Icon>();
    private List<EquipItem_Icon> _summonItemIcons = new List<EquipItem_Icon>();

    private const string EquipItem_Icon = "EquipItem_Icon";

    [SerializeField]
    private int EquipItemCount;

    private void Start()
    {
        for(int i = 0; i < EquipItemCount; i++)
        {
            EquipItem_Icon equipItem_Icon = UIManager.Instance.CreateUI(EquipItem_Icon,
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

    public void UnEquippedSkill(SummonItemInfo summonItemInfo)
    {
        if(!_equippedSkill_Icons.TryGetValue(summonItemInfo, out EquipItem_Icon equipItem_Icon))
        {
            Debug.LogError($"{summonItemInfo.ItemName} is not Equipped");
            return;
        }

        equipItem_Icon.ReSetSummonItem();

        _equippedSkill_Icons.Remove(summonItemInfo);
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
