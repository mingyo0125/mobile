using System;
using UnityEngine;

public interface IDamageable
{
    // HitableÀÌ¶û DamageableÀÌ¶û ³ª´©¼À
	public event Action<TakeDamageInfo> OnTakeDamagedEvent;
	public event Action OnDieEvent;

	public void TakedDamage(TakeDamageInfo takeDamageInfo);
    public void Die();

    public float MaxHP { get; set; }
    public float CurrentHP { get; set; }
    public Collider2D EntityCollider { get; set;}
}
