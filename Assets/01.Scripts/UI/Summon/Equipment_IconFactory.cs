using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Equipment_IconFactory : SummonItemIconFactory
{
    protected override List<SummonItemInfo> GetSummonItems()
    {
        var equipmentManager = SummonItemManager<EquipmentInfo>.Instance as EquipmentManager;
        List<SummonItemInfo> list = new List<SummonItemInfo>(equipmentManager.EquipmentInfoList);
        return list;
    }
}
