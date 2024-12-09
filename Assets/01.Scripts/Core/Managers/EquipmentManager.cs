using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentManager : SummonItemManager<EquipmentInfo>
{
    [SerializeField]
    private EquipmentInfoListSO _equipmentInfoListSO;

    public Dictionary<string, EquipmentInfo> EquipmentInfoList { get; private set; } = new Dictionary<string, EquipmentInfo>();

    private Equipment_Inventory _equipment_Inventory;

    protected override void Awake()
    {
        foreach (EquipmentInfoSO equipmentInfoSO in _equipmentInfoListSO.EquipmentInfoList)
        {
            EquipmentInfo equipmentInfo = new EquipmentInfo(equipmentInfoSO.EquipmentInfo);
            EquipmentInfoList.Add(equipmentInfo.ItemId, equipmentInfo);
        }

        base.Awake();
    }

    private void Start()
    {
        _equipment_Inventory = FindAnyObjectByType<Equipment_Inventory>();

    }

    protected override List<EquipmentInfo> GetSummonItems()
    {
        return EquipmentInfoList.Values.ToList();
    }

    public override void UnEquipSummonItem(string itemId)
    {
        base.UnEquipSummonItem(itemId);
    }

    public override bool EquipSummonItem(string itemId)
    {
        if (!EquipmentInfoList.TryGetValue(itemId, out EquipmentInfo equipmentInfo)) { return false; }

        _equipment_Inventory.EquipItem(equipmentInfo);

        return base.EquipSummonItem(itemId);
    }
}
