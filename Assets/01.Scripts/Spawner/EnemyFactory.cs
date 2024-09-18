using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : EntityFactory<Enemy>
{
    private Queue<Enemy> _spawnedEnemies = new(); // Test

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // Test
        {
            Enemy enemy = CustomRandom.GetRandomElement(_spawnEntitys);
            _spawnedEnemies.Enqueue(enemy);
            SpawnObject(enemy.name, transform.position);
        }

        if (Input.GetKeyDown(KeyCode.D)) // Test
        {
            PoolManager.Instance.DestroyObject(FindAnyObjectByType<Enemy>());
        }
    }
}
