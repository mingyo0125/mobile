using System;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponStatSO _weaponStatSO;

    public WeaponStat WeaponStat { get; private set; }

    private WeaponAnimator _weaponAnimator;

    private void Awake() // ���׷��̵� �Ϸ��� ����ϰ�, ��� ������ ����. �����ϸ� �� ������Ʈ �����ؼ� �ٲ㳢�� ��������
    {
		WeaponStat = new WeaponStat(_weaponStatSO.WeaponStat);

		_weaponAnimator = transform.Find("Visual").GetComponent<WeaponAnimator>();
    }

    public virtual void SetAttack()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.
            Append(transform.DORotate(new Vector3(0, 0, -360), 0.6f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
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
