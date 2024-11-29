using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : ObjectFactory<Enemy>
{
    [SerializeField]
    private Transform _minBound, _maxBound;

    private ItemFactory _itemFactory;
    private CoinFactory _coinFactory;

    protected override void Awake()
    {
        base.Awake();

        _itemFactory = FindAnyObjectByType<ItemFactory>();
        _coinFactory = FindAnyObjectByType<CoinFactory>();

        Vector3 middleRight = Camera.main.ViewportToWorldPoint(new Vector3(2f, 0.55f, Camera.main.nearClipPlane));

        _minBound.parent.position = middleRight;
    }

    public void SpawnEnemy(int spawnCount, params Action<Vector2>[] onDieEvents)
    {
        StartCoroutine(SpawnEnemyCorou(spawnCount, onDieEvents));
    }

    private IEnumerator SpawnEnemyCorou(int spawnCount, Action<Vector2>[] onDieEvents)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Enemy enemyPrefab = Utils.GetRandomElement(_spawnEntitys);
            Enemy spawnedEnemy = SpawnObject(enemyPrefab.name, Utils.GetRandomSpawnPos(_minBound.position, _maxBound.position)) as Enemy;

            spawnedEnemy.OnDieEvent = null;

            spawnedEnemy.OnDieEvent += _itemFactory.SpawnItem;
            spawnedEnemy.OnDieEvent += _coinFactory.SpawnCoin;

            foreach (Action<Vector2> action in onDieEvents)
            {
                spawnedEnemy.OnDieEvent += action;
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.2f));
        }
    }

    public void SpawnBoss()
    {

    }
}
