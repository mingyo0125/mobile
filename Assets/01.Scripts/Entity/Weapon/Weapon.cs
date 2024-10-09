using System;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponStatSO _weaponStatSO;

    public WeaponStat WeaponStat { get; private set; }

    private Action OnAttackEvent = null;
    private Action OnEndAttackEvent = null;

    private void Awake() // 업그레이드 하려면 사야하고, 사면 무조건 장착. 장착하면 이 오브젝트 생성해서 바꿔끼는 형식으로
    {
		WeaponStat = new WeaponStat(_weaponStatSO.WeaponStat);
    }

    public virtual void SetAttack()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.
             Append(transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -360), WeaponStat.AttackDelay, RotateMode.WorldAxisAdd).SetEase(Ease.Linear))
            .InsertCallback(WeaponStat.AttackDelay * 0.5f, () => OnAttackEvent?.Invoke())
            .OnComplete(() => OnEndAttackEvent?.Invoke());

    }

    public virtual void SetIdle()
    {
        transform.DOKill();
        transform.rotation = Quaternion.identity;
	}

    public void SubscribeEndAnimationEvent(Action endAnimationEvent)
    {
        OnEndAttackEvent = endAnimationEvent;
        //weaponAnimator.OnEndAttackEvent += endAnimationEvent;
	}

    public void SubscribeAttackEvent(Action attackEvent)
    {
        OnAttackEvent = attackEvent;
        //_weaponAnimator.OnAttackEvent += attackEvent;
	}

}
