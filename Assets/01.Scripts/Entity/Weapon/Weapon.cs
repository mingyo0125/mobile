using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponStatSO _weaponStatSO;

    public WeaponStat WeaponStat { get; private set; }

    private Animator _animator;

    private void Awake() // ���׷��̵� �Ϸ��� ����ϰ�, ��� ������ ����. �����ϸ� �� ������Ʈ �����ؼ� �ٲ㳢�� ��������
    {
		WeaponStat = new WeaponStat(_weaponStatSO.WeaponStat);

        _animator = transform.Find("Visual").GetComponent<Animator>();
    }

    public virtual void Attack()
    {
        _animator.SetTrigger("AttackTrigger");

	}
}
