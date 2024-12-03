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

		_owner.StopImmediatetly();

        _owner.SetIsAttack(true);

        Attack();
    }

	protected abstract void Attack();

    public override void ExitState()
    {
        base.ExitState();

        _owner.SetIsAttack(false);
    }
}
