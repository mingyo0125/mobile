using System;
using UnityEngine;

public abstract class EntityAttackState<T, G> : EntityState<T, G> where T : Enum where G : Entity<T, G>
{
    public EntityAttackState(G entity, EntityStateMachine<T, G> entityStateMachine):
                             base(entity, entityStateMachine)
    {
        _entity.EquipWeapon?.SubscribeEndAnimationEvent(EnterState);
        _entity.EquipWeapon?.SubscribeAttackEvent(TakeDamage);
	}

	public override void EnterState()
	{
		PlayAttackAnimaion();
	}

	public void PlayAttackAnimaion()
    {
		if (!GetAttackable())
		{
			ChangeMoveState();
			return;
		}

		_entity.EquipWeapon?.Attack();
	}

	private bool GetAttackable()
	{
		return _entity.GetInRange().Item1;
	}

	private void TakeDamage()
	{
		foreach(Collider2D item in _entity.GetInRange().Item2)
		{
			if (item.TryGetComponent(out IDamageable component))
			{
				component.TakeDamage(_entity.GetDamage());
			}
			else
			{
				Debug.Log($"{component} not have IDamageable");
			}
		}
		
	}

	public abstract void ChangeMoveState();
}
