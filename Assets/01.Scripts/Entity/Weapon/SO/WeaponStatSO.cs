using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/WeaponStat")]
public class WeaponStatSO : ScriptableObject
{
    [field: SerializeField]
    public WeaponStat WeaponStat { get; private set; }
}
