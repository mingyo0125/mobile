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
		base.EnterState();

		if (!GetAttackable())
		{
			ChangeIdleState();
			return;
		}

		Vector2 shortestPos = _entity.GetShortestTargetPos(_entity.GetInRange(100f).Item2);
		_entity.CheckFacingDir(shortestPos);
		_entity.EquipWeapon?.SetAttack();
	}

	public override void ExitState()
	{
		_entity.EquipWeapon?.SetIdle();
	}

	private bool GetAttackable()
	{
		return _entity.GetInRange(_entity.CheckRangeDistance).Item1;
	}

	private void TakeDamage()
	{
		foreach (Collider2D item in _entity.GetInRange(_entity.CheckRangeDistance).Item2)
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

	public abstract void ChangeIdleState();
}
