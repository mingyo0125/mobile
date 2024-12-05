using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Equipment/Info")]
public class EquipmentInfoSO : ScriptableObject
{
    [field: SerializeField]
    public EquipmentInfo EquipmentInfo { get; private set; }
}
