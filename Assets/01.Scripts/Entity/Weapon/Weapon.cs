using System;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponStatSO _weaponStatSO;

    public WeaponStat WeaponStat { get; private set; }

    private WeaponAnimator _weaponAnimator;

    private Action OnAttackEvent;

    private void Awake() // ���׷��̵� �Ϸ��� ����ϰ�, ��� ������ ����. �����ϸ� �� ������Ʈ �����ؼ� �ٲ㳢�� ��������
    {
		WeaponStat = new WeaponStat(_weaponStatSO.WeaponStat);

		_weaponAnimator = transform.Find("Visual").GetComponent<WeaponAnimator>();
    }

    public virtual void SetAttack()
    {
        OnAttackEvent?.Invoke();
        Sequence sequence = DOTween.Sequence();
        sequence.
            Append(transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -360), 0.4f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
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
        OnAttackEvent = attackEvent;
        //_weaponAnimator.OnAttackEvent += attackEvent;
	}

}
