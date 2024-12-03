using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttackState : EntityAttackState<PlayerStateType, Player>
{
    public PlayerAttackState(Player player, EntityStateMachine<PlayerStateType, Player> entityStateMachine):
                             base(player, entityStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Enter AttackState");
    }

    protected override void Attack()
    {
        //_owner.SkillHolder.PlaySkill("Fireball");
    }

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Exit AttackState");
    }
}
