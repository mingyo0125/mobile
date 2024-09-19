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
            Enemy enemy = CustomRandom.GetRandomElement(_spawnEntitys);
            SpawnObject(enemy.name, GetRandomSpawnPos());

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private Vector2 GetRandomSpawnPos()
    {
        float randomX = Random.Range(_minBound.position.x, _maxBound.position.x);
        float randomY = Random.Range(_minBound.position.y, _maxBound.position.y);

        return new Vector2(randomX, randomY);
    }
}
