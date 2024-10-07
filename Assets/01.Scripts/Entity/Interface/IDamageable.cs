using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
	public event Action<bool, float> OnTakeDamagedEvent;
	public event Action OnDieEvent;

	public void TakedDamage(bool isCritical, float damage);
    public void Die();

    public float MaxHP { get; set; }
    public float CurrentHP { get; set; }
}
