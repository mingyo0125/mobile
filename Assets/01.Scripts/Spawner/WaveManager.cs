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
        _enemyFactory.SpawnEnemy(spawnedEnmiesCount, IncreaseDeadEnemyCount);
    }

    private void Update()
    {
        if (deadEnmiesCount >= spawnedEnmiesCount)
        {
            _enemyFactory.SpawnEnemy(spawnedEnmiesCount, IncreaseDeadEnemyCount);
            deadEnmiesCount = 0;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            foreach (var item in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
            {
                item.Die();
            }
        }
    }

    private void IncreaseDeadEnemyCount(Vector2 vector2)
    {
        deadEnmiesCount++;
    }
}
