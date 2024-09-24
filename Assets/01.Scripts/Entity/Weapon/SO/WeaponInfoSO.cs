using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct WeaponInfo
{
    public string Name;
    public string Description;

    public WeaponStatSO WeaponStat;
}

[CreateAssetMenu(menuName = "SO/Weapon/WeaponInfo")]
public class WeaponInfoSO : ScriptableObject
{
    [field: SerializeField]
    public WeaponInfo WeaponInfo { get; set; }
}
