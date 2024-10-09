using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //나중에 SO로 빼기
    public float CurrentHP { get; set; }

    public event Action<TakeDamageInfo> OnTakeDamagedEvent = null;
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


	public virtual void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        //if (CurrentHP <= 0) { return; } // 나중에 콜라이더를 꺼는걸로 바꾸셈
        OnTakeDamagedEvent?.Invoke(takeDamageInfo);
        // 넉백하면서 스피드 0 하고 잠시동안 무적



        CurrentHP -= takeDamageInfo.Damage;

        if (CurrentHP <= 0) { Die(); }
        else
        {
			EntityAnimatorCompo.SetFloat("Speed", -1f);
			EntityAnimatorCompo.SetTrigger("HitTrigger");

            FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Hit, takeDamageInfo);
        }
    }

    public virtual void Die()
    {
		OnDieEvent?.Invoke();
        FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Die);
        EntityAnimatorCompo.SetFloat("Speed", -1f);
		EntityAnimatorCompo.SetTrigger("DieTrigger");

		// DoSomething
	}

    private void HealthDisable()
    {
		EntityAnimatorCompo.OnDieAnimationEndEvent -= DieAnimationEndEvent;
	}
}
