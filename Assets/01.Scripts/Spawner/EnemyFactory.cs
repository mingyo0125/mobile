using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : EntityFactory<Enemy>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // Test
        {
            Enemy enemy = CustomRandom.GetRandomElement(_spawnEntitys);
            SpawnObject(enemy.name, transform.position);
        }
    }
}
