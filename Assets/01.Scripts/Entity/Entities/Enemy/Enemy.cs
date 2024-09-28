using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity<EnemyStateType, Enemy>
{
    protected override void CreateStateMachine()
    {
        StateMachine = new EnemyStateMachine(this);
    }
}