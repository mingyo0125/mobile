using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : ObjectFactory<Enemy>
{
    [SerializeField]
    private Transform _bounds, _minBound, _maxBound;

    [SerializeField]
    private float spawnTime;

    private ItemFactory _itemFactory;
    private CoinFactory _coinFactory;

    protected override void Awake()
    {
        base.Awake();

        _itemFactory = FindAnyObjectByType<ItemFactory>();
        _coinFactory = FindAnyObjectByType<CoinFactory>();

        Vector3 middleRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, Camera.main.nearClipPlane));

        _minBound.parent.position = middleRight;
    }

    public void SpawnEnemy(int spawnCount, params Action<Vector2>[] onDieEvents)
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Enemy enemyPrefab = Utils.GetRandomElement(_spawnEntitys);
            Enemy spawnedEnemy = SpawnObject(enemyPrefab.name, Utils.GetRandomSpawnPos(_minBound.position, _maxBound.position)) as Enemy;

            spawnedEnemy.OnDieEvent += _itemFactory.SpawnItem;
            spawnedEnemy.OnDieEvent += _coinFactory.SpawnCoin;


            foreach(Action<Vector2> action in onDieEvents)
            {
                spawnedEnemy.OnDieEvent += action;
            }
        }
    }

    public void SpawnBoss()
    {

    }
}
