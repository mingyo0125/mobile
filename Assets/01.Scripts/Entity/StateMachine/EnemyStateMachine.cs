using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : EntityStateMachine<EnemyStateType, Enemy>
{
    public EnemyStateMachine(Enemy enemy) : base(enemy)
    {
    }
}
