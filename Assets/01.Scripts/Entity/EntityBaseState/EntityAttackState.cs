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

        CoroutineUtil.CallWaitForSeconds(_owner.GetAttackDelay(), EnterState);

        if (!GetAttackable())
		{
			ChangeNextState();
			return;
		}

        Attack();
    }

	protected abstract void Attack();

	protected virtual void EndAttack()
	{

	}

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Exit");
    }

    public abstract void ChangeNextState();
}
