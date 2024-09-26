using System;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponStatSO _weaponStatSO;

    public WeaponStat WeaponStat { get; private set; }

    private WeaponAnimator _weaponAnimator;

    private void Awake() // 업그레이드 하려면 사야하고, 사면 무조건 장착. 장착하면 이 오브젝트 생성해서 바꿔끼는 형식으로
    {
		WeaponStat = new WeaponStat(_weaponStatSO.WeaponStat);

		_weaponAnimator = transform.Find("Visual").GetComponent<WeaponAnimator>();
    }

    public virtual void Attack()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.
            Append(transform.DORotate(new Vector3(0, 0, -360), 0.6f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        _weaponAnimator.Attack();
	}

    public void SubscribeEndAnimationEvent(Action endAnimationEvent)
    {
        _weaponAnimator.OnEndAttackEvent += endAnimationEvent;
	}

    public void SubscribeAttackEvent(Action attackEvent)
    {
		_weaponAnimator.OnAttackEvent += attackEvent;
	}
    
}
