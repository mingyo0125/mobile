using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Equipment/InfoList")]
public class EquipmentInfoListSO : ScriptableObject
{
    [field: SerializeField]
    public List<EquipmentInfoSO> EquipmentInfoList { get; private set; }
}
