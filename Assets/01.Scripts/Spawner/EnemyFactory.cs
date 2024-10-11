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
    private CoinFactory _coinFactory;

    protected override void Awake()
    {
        base.Awake();

        _itemFactory = FindAnyObjectByType<ItemFactory>();
        _coinFactory = FindAnyObjectByType<CoinFactory>();
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
            spawnedEnemy.OnDieEvent += _coinFactory.SpawnCoin;

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
