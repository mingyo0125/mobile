using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
	public event Action<float> OnTakeDamagedEvent;
	public event Action OnDieEvent;

	public void TakeDamage(float damage);
    public void Die();

    public float MaxHP { get; set; }
    public float CurrentHP { get; set; }
}
