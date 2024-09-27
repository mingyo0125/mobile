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

	private void InitializeHealth()
    {
        MaxHP = _entityStatSO.EntityStat.MaxHP;
        CurrentHP = MaxHP;

        EntityAnimatorCompo.OnDieAnimationEndEvent += () => PoolManager.Instance.DestroyObject(this);
        // 나중에 디졸브로 사라지게. 지금은 걍 지우겠음
	}

    public virtual void TakeDamage(float damage)
    {
        if (CurrentHP <= 0) { return; } // 나중에 콜라이더를 꺼는걸로 바꾸셈

        CurrentHP -= damage;
		EntityAnimatorCompo.SetFloat("Speed", -1f);
        EntityAnimatorCompo.SetTrigger("HitTrigger");

		Debug.Log($"{gameObject}: TakeDamage:{damage}, CurHp:{CurrentHP}");
        if (CurrentHP <= 0) { Die(); }
        else { OnTaKeDamagedEvent?.Invoke(damage); }
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject} Die");
		OnDieEvent?.Invoke();
		EntityAnimatorCompo.SetFloat("Speed", -1f);
		EntityAnimatorCompo.SetTrigger("DieTrigger");

		// DoSomething
	}
}
