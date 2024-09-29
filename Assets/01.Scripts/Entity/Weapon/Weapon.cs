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

    public virtual void SetAttack()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.
            Append(transform.DORotate(new Vector3(0.0f, 0.0f, -360), 0.4f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
        _weaponAnimator.SetAttackAnimation();
	}

    public virtual void SetIdle()
    {
        transform.DOKill();
        transform.rotation = Quaternion.identity;
        _weaponAnimator.SetIdleAnimation();
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
