using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //���߿� SO�� ����
    public float CurrentHP { get; set; }

    public event Action<bool, float> OnTakeDamagedEvent = null;
	public event Action OnDieEvent = null;

    private Action DieAnimationEndEvent = null;

	private void HealthAwake()
    {
        MaxHP = _entityStatSO.EntityStat.MaxHP;

        DieAnimationEndEvent = () => PoolManager.Instance.DestroyObject(this);
	}

    private void InitializeHealth()
    {
		CurrentHP = MaxHP;
		EntityAnimatorCompo.OnDieAnimationEndEvent += DieAnimationEndEvent;
	}

	public virtual void TakedDamage(bool isCritical, float damage)
    {
        //if (CurrentHP <= 0) { return; } // ���߿� �ݶ��̴��� ���°ɷ� �ٲټ�
        OnTakeDamagedEvent?.Invoke(isCritical, damage);
        // �˹��ϸ鼭 ���ǵ� 0 �ϰ� ��õ��� ����
        CurrentHP -= damage;

        if (CurrentHP <= 0) { Die(); }
        else
        {
			EntityAnimatorCompo.SetFloat("Speed", -1f);
			EntityAnimatorCompo.SetTrigger("HitTrigger");

            FeedbackPlayerCompo.PlayFeedback(FeedbackTypes.Hit);
        }
    }

    public virtual void Die()
    {
		OnDieEvent?.Invoke();
        FeedbackPlayerCompo.PlayFeedback(FeedbackTypes.Die);
        EntityAnimatorCompo.SetFloat("Speed", -1f);
		EntityAnimatorCompo.SetTrigger("DieTrigger");

		// DoSomething
	}

    private void HealthDisable()
    {
		EntityAnimatorCompo.OnDieAnimationEndEvent -= DieAnimationEndEvent;
	}
}
