using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : EntityFactory<Enemy>
{
    [SerializeField]
    private Transform _minBound, _maxBound;

    [SerializeField]
    private float spawnTime;

    private ItemFactory _itemFactory;

    protected override void Awake()
    {
        base.Awake();

        _itemFactory = FindAnyObjectByType<ItemFactory>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyCorou());
    }

    private IEnumerator SpawnEnemyCorou()
    {
        while (true)
        {
            Enemy enemyPrefab = Utils.GetRandomElement(_spawnEntitys);
            Enemy spawnedEnemy = SpawnObject(enemyPrefab.name, Utils.GetRandomSpawnPos(_minBound.position, _maxBound.position)) as Enemy;

            spawnedEnemy.OnDieEvent += _itemFactory.SpawnItem;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
