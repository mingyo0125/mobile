using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSummonUI : UI_Component
{
    [SerializeField]
    private Transform _spawnParentTrm;

    private ISummonFactory _summonItemFactory;

    [SerializeField]
    private ItemType _itemType;

    private void Awake()
    {
        _summonItemFactory = GetComponent<ISummonFactory>();
    }

    public override void UpdateUI()
    {
    }

    public void SpawnSummonItem(int summonCount)
    {
        switch (_itemType)
        {
            case ItemType.Skill:
                _summonItemFactory.GetFactory<SkillInfo>().SpawnSummonItem(_spawnParentTrm, summonCount);
                break;
            case ItemType.Equipment:
                _summonItemFactory.GetFactory<EquipmentInfo>().SpawnSummonItem(_spawnParentTrm, summonCount);
                break;
        }
    }
}
