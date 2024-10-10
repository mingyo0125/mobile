using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : EntityFactory<Enemy>
{
    [SerializeField]
    private Transform _minBound, _maxBound;

    [SerializeField]
    private float spawnTime;

    private void Start()
    {
        StartCoroutine(SpawnEnemyCorou()); // Test
    }

    private IEnumerator SpawnEnemyCorou()
    {
        while (true)
        {
            Enemy enemy = Utils.GetRandomElement(_spawnEntitys);
            SpawnObject(enemy.name, Utils.GetRandomSpawnPos(_minBound.position, _maxBound.position));

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
