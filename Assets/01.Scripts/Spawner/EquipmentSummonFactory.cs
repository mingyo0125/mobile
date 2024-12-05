using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSummonFactory : SummonItemFactory<EquipmentInfo>
{
    public override List<EquipmentInfo> GetCanSummonItems()
    {
        var equipmentManager = EquipmentManager.Instance as EquipmentManager;
        foreach(var a in equipmentManager.EquipmentInfoList)
        {
            Debug.Log(a);
        }
        return equipmentManager.EquipmentInfoList;
    }
}
