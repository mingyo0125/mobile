using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
    public UnityEvent OnDieEvent { get; set; }
    public void TakeDamage(float damage);
    public void Die();

    public float MaxHP { get; set; }
    public float CurrentHP { get; set; }
}
