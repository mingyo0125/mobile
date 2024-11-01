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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            foreach (var item in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
            {
                item.Die();
            }
        }
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
