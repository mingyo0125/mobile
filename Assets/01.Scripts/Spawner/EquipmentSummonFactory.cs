using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSummonFactory : SummonItemFactory<EquipmentInfo>
{
    public override List<EquipmentInfo> GetCanSummonItems()
    {
        var equipmentManager = EquipmentManager.Instance as EquipmentManager;
        return equipmentManager.EquipmentInfoList;
    }
}
