using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : EnemyFactory
{

    public override void SpawnEnemy(int spawnCount, params Action<Vector2>[] onDieEvents)
    {
        base.SpawnEnemy(spawnCount, onDieEvents);

        Debug.Log("?!");
    }
}
