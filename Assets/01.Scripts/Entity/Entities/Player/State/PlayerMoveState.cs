using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMoveState : EntityMoveState<PlayerStateType, Player>
{
    public PlayerMoveState(Player player, EntityStateMachine<PlayerStateType, Player> entityStateMachine):
                           base(player, entityStateMachine)
    {
    }

    public override void FixedUpdateState()
    {
		bool isInRange = _entity.GetInRange(100f).Item1; // 있기만 하면 어디에 있던 쫓아감
		if (isInRange)
		{
            Collider2D[] inRangeEntities = _entity.GetInRange(100f).Item2;

			Collider2D shortestCollider = inRangeEntities.FirstOrDefault();

            foreach(Collider2D collider in inRangeEntities)
            {
                bool isShortestDistance = Vector3.Distance(_entity.transform.position, collider.transform.position) <
                                          Vector3.Distance(_entity.transform.position, shortestCollider.transform.position);

				if (isShortestDistance)
				{
                    shortestCollider = collider;
				}
            }
			_entity.Move(shortestCollider.transform.position);
		}

    }

    public override void UpdateState()
    {
        bool isInRange = _entity.GetInRange(_entity.CheckRangeDistance).Item1;
        if (isInRange)
        {
            _entityStateMachine.ChangeState(PlayerStateType.Attack);
        }
        
    }
}
