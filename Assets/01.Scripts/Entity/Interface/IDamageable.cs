using System;
using UnityEngine;

public interface IDamageable
{
	public event Action<TakeDamageInfo> OnTakeDamagedEvent;
	public Action<Vector2> OnDieEvent { get; set; }

	public void TakedDamage(TakeDamageInfo takeDamageInfo);
    public void Die();

    public float MaxHP { get; set; }
    public float HP { get; set; }
    public Collider2D EntityCollider { get; set;}
}
