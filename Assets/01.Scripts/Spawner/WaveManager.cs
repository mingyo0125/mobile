using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoSingleTon<WaveManager>
{
    [SerializeField]
    private EnemyFactory _enemyFactory;
    [SerializeField]
    private BossFactory _bossFactory;

    [SerializeField]
    private int spawnedEnmiesCount;

    [SerializeField]
    private int deadEnmiesCount;

    public int CurStageCount { get; private set; }
    public int CurWaveCount { get; private set; }

    private const int bossWaveNumber = 2;

    private void Start()
    {
        _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
    }

    public void IncreaseDeadEnemyCount()
    {
        deadEnmiesCount++;

        if (deadEnmiesCount == spawnedEnmiesCount)
        {
            if (CurWaveCount == bossWaveNumber)
            {
                CurStageCount++;
            }

            deadEnmiesCount = 0;
            CurWaveCount++;

            if (CurWaveCount % bossWaveNumber == 0)
            {
                _bossFactory.SpawnEnemy(spawnedEnmiesCount);
                return;
            }

            _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
        }
    }
}
