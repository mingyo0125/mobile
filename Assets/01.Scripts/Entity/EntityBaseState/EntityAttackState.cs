using System;
using UnityEngine;

public abstract class EntityAttackState<T, G> : EntityState<T, G> where T : Enum where G : Entity<T, G>
{
    public EntityAttackState(G entity, EntityStateMachine<T, G> entityStateMachine):
                             base(entity, entityStateMachine)
    {
		if (_owner.EquipWeapon != null)
		{
            _owner.EquipWeapon?.SubscribeEndAnimationEvent(EnterState);
        }
    }

	public override void EnterState()
	{
		base.EnterState();

        if (!GetAttackable())
		{
			ChangeIdleState();
			return;
		}

        Vector2 shortestPos = GetShortestTargetPos(GetInRange(100f).Item2);
		_owner.CheckFacingDir(shortestPos);

		if(_owner.EquipWeapon != null)
		{
            _owner.EquipWeapon?.SetAttack();
        }
		else
		{
            TakeDamage();
            CoroutineUtil.CallWaitForSeconds(_owner.EntityStat.AttackDelay, EnterState);
		}
    }

	public override void ExitState()
	{
		_owner.EquipWeapon?.SetIdle();
	}

	protected virtual void TakeDamage() { }

	protected virtual void EndAttack()
	{

	}

	public abstract void ChangeIdleState();
}
