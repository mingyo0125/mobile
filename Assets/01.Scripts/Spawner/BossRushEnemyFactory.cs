using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushEnemyFactory : EnemyFactory
{
    private int curLevel;

    public void SetLevel(int level)
    {
        curLevel = level;
    }

    protected override Enemy GetEnemy()
    {
        if (_spawnEntitys.Length < curLevel)
        {
            Debug.LogError($"{name} doesn't have {curLevel} Stage Enemy");
            return null;
        }

        return _spawnEntitys[curLevel - 1];
    }
}
