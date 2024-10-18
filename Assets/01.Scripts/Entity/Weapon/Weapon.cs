using System;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    private Action OnEndAttackEvent = null;

    private TakeDamageInfo _takeDamageInfo;

    private bool isAttacking = false;

    private StatController _playerStatController;

    private void Start()
    {
        _playerStatController = GameManager.Instance.GetPlayer().EntityStatController;
    }

    public virtual void SetAttack()
    {
        isAttacking = true;

        float attackTime = _playerStatController.GetStatValue(StatType.AttackDelay);
        Sequence sequence = DOTween.Sequence();
        sequence.
             Append(transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -360), attackTime, RotateMode.WorldAxisAdd).SetEase(Ease.Linear))
            .InsertCallback(attackTime, () => isAttacking = false)
            .OnComplete(() =>
            {
                OnEndAttackEvent?.Invoke();
            });

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isAttacking && other.TryGetComponent(out IDamageable damagedEntity))
        {
            damagedEntity.TakedDamage(_takeDamageInfo);
        }
    }

    public void SetTakeDamageInfo(TakeDamageInfo takeDamageInfo)
    {
        _takeDamageInfo = takeDamageInfo;
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
}
