using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatSO : ScriptableObject
{
    [field: SerializeField]
    public WeaponStat WeaponStat { get; private set; }
}
