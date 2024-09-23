using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //���߿� SO�� ����
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
        if (CurrentHP <= 0) { Die(); }
    }

    public virtual void Die()
    {
        // DoSomething
    }
}
