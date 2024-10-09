using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
    // Hitable�̶� Damageable�̶� ������
	public event Action<TakeDamageInfo> OnTakeDamagedEvent;
	public event Action OnDieEvent;

	public void TakedDamage(TakeDamageInfo takeDamageInfo);
    public void Die();

    public float MaxHP { get; set; }
    public float CurrentHP { get; set; }
}
