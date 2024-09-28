using System;
using System.Linq;
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
		_entity.EquipWeapon?.SetAttack();
	}

	private bool GetAttackable()
	{
		return _entity.GetInRange(_entity.CheckRangeDistance).Item1;
	}

	public override void UpdateState()
	{
		if (!GetAttackable())
		{
			ChangeIdleState();
		}
	}

	public override void ExitState()
	{
		_entity.EquipWeapon?.SetIdle();
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
