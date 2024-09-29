using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //나중에 SO로 빼기
    public float CurrentHP { get; set; }

    public event Action<float> OnTaKeDamagedEvent = null;
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

	public virtual void TakeDamage(float damage)
    {
        if (CurrentHP <= 0) { return; } // 나중에 콜라이더를 꺼는걸로 바꾸셈

        CurrentHP -= damage;

		//Debug.Log($"{gameObject}: TakeDamage:{damage}, CurHp:{CurrentHP}");
        if (CurrentHP <= 0) { Die(); }
        else
        {
			EntityAnimatorCompo.SetFloat("Speed", -1f);
			EntityAnimatorCompo.SetTrigger("HitTrigger");

			OnTaKeDamagedEvent?.Invoke(damage);
        }
    }

    public virtual void Die()
    {
		OnDieEvent?.Invoke();
		EntityAnimatorCompo.SetFloat("Speed", -1f);
		EntityAnimatorCompo.SetTrigger("DieTrigger");

		// DoSomething
	}

    private void HealthDisable()
    {
		EntityAnimatorCompo.OnDieAnimationEndEvent -= DieAnimationEndEvent;
	}
}
