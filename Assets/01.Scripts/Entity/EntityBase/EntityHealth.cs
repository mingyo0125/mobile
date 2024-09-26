using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //나중에 SO로 빼기
    public float CurrentHP { get; set; }

    [field: SerializeField]
    public UnityEvent OnDieEvent { get; set; }

    private void InitializeHealth()
    {
        MaxHP = _entityStatSO.EntityStat.MaxHP;
        CurrentHP = MaxHP;
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHP -= damage;
		EntityAnimatorCompo.SetFloat("Speed", -1f);
        EntityAnimatorCompo.SetTrigger("HitTrigger");

		Debug.Log($"{gameObject}: TakeDamage:{damage}, CurHp:{CurrentHP}");
        if (CurrentHP <= 0) { Die(); }
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject} Die");
        // DoSomething
    }
}
