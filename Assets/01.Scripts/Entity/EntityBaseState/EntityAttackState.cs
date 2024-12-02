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

        CoroutineUtil.CallWaitForSeconds(_owner.GetAttackDelay(), EndAttack);

        Attack();
    }

	protected abstract void Attack();

	protected virtual void EndAttack()
	{
        if (!GetAttackable())
        {
            ChangeNextState();
            return;
        }

        EnterState();
    }

    public abstract void ChangeNextState();
}
