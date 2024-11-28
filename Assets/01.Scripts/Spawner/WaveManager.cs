using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoSingleTon<WaveManager>
{
    private EnemyFactory _enemyFactory;

    [SerializeField]
    private int spawnedEnmiesCount;

    [SerializeField]
    private int deadEnmiesCount;

    private void Awake()
    {
        _enemyFactory = FindAnyObjectByType<EnemyFactory>();
    }

    private void Start()
    {
        _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
    }

    public void IncreaseDeadEnemyCount()
    {
        deadEnmiesCount++;

        if (deadEnmiesCount == spawnedEnmiesCount)
        {
            _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
            deadEnmiesCount = 0;
        }
    }
}
