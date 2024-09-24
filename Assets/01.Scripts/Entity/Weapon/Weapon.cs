using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponStatSO _weaponStatSO;

    private WeaponStat _weaponStat;

    private void Awake() // 업그레이드 하려면 사야하고, 사면 무조건 장착. 장착하면 이 오브젝트 생성해서 바꿔끼는 형식으로
    {
        _weaponStat = new WeaponStat(_weaponStatSO.WeaponStat);
    }

}
