using System;
using UnityEngine;

public abstract class EntityAttackState<T, G> : EntityState<T, G> where T : Enum where G : Entity<T, G>
{
    public EntityAttackState(G entity, EntityStateMachine<T, G> entityStateMachine):
                             base(entity, entityStateMachine)
    {
        _entity.EquipWeapon?.SubscribeEndAnimationEvent(EnterState);
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
	public abstract void ChangeMoveState();
}
