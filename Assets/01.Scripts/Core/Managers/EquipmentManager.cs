using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : SummonItemManager<EquipmentInfo>
{
    [SerializeField]
    private EquipmentInfoListSO _equipmentInfoListSO;

    public List<EquipmentInfo> EquipmentInfoList { get; private set; } = new List<EquipmentInfo>();
     
    protected override void Awake()
    {
        foreach (EquipmentInfoSO equipmentInfoSO in _equipmentInfoListSO.EquipmentInfoList)
        {
            EquipmentInfoList.Add(equipmentInfoSO.EquipmentInfo);
        }

        base.Awake();
    }

    protected override List<EquipmentInfo> GetSummonItems()
    {
        return EquipmentInfoList;
    }
}
