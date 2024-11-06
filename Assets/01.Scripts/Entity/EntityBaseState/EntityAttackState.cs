using System;
using UnityEngine;

public abstract class EntityAttackState<T, G> : EntityState<T, G> where T : Enum where G : Entity<T, G>
{
    public EntityAttackState(G entity, EntityStateMachine<T, G> entityStateMachine):
                             base(entity, entityStateMachine)
    {
    }

	public override void EnterState()
	{
		base.EnterState();

        if (!GetAttackable())
		{
			ChangeMoveState();
			return;
		}

        TakeDamage();

        CoroutineUtil.CallWaitForSeconds(_owner.GetAttackDelay(), EnterState);
    }

	protected abstract void TakeDamage();

	protected virtual void EndAttack()
	{

	}

	public abstract void ChangeMoveState();
}
