using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityState<T, G> : IRangeCheckable where T : Enum where G : Entity<T, G>
{
    protected G _owner;
    protected EntityStateMachine<T, G> _stateMachine;

    public EntityState(G entity, EntityStateMachine<T, G> entityStateMachine)
    {
        _owner = entity;
        _stateMachine = entityStateMachine;
    }

    public virtual void EnterState()
    {
		if (_owner.StateMachine.PrevState?.GetType() == GetType())
		{
			return;
		}
	}

    public virtual void ExitState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }

    #region Range

    public (bool, Collider2D[]) GetInRange(float checkRange)
    {
        Collider2D[] inRangeColliders = Physics2D.OverlapCircleAll(_owner.transform.position, checkRange, _owner.CheckLayer);
        return (inRangeColliders.Length > 0, inRangeColliders);
    }

    public Vector2 GetShortestTargetPos(Collider2D[] inRangeTargets)
    {
        Collider2D shortestCollider = inRangeTargets.FirstOrDefault();

        foreach (Collider2D collider in inRangeTargets)
        {
            bool isShortestDistance = Vector3.Distance(_owner.transform.position, collider.transform.position) <
                                      Vector3.Distance(_owner.transform.position, shortestCollider.transform.position);

            if (isShortestDistance)
            {
                shortestCollider = collider;
            }
        }

        if(shortestCollider != null)
        {
            return shortestCollider.transform.position;
        }

        return Vector2.zero;
    }

    public bool GetAttackable()
    {
        return GetInRange(_owner.EntityStatController.GetStatValue(StatType.AttackRange)).Item1;
    }

    #endregion
}
