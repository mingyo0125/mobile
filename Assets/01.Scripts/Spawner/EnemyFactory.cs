using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : ObjectFactory<Enemy>
{
    private Transform _minBound, _maxBound;

    private ItemFactory _itemFactory;
    private CoinFactory _coinFactory;

    protected DefaultWaveUI _defaultWaveUI;

    protected int curEnemyType => WaveManager.Instance.CurStageCount;

    protected override void Awake()
    {
        base.Awake();

        _itemFactory = FindAnyObjectByType<ItemFactory>();
        _coinFactory = FindAnyObjectByType<CoinFactory>();
        _defaultWaveUI = FindAnyObjectByType<DefaultWaveUI>();


        Transform playerTrm = GameManager.Instance.GetPlayerTrm();

        _minBound = playerTrm.Find("PlayerFollowPoint/EnemySpawnBounds/MinBounds");
        _maxBound = playerTrm.Find("PlayerFollowPoint/EnemySpawnBounds/MaxBounds");

        Vector3 middleRight = Camera.main.ViewportToWorldPoint(new Vector3(2f, 0.55f, Camera.main.nearClipPlane));

        _minBound.parent.position = middleRight;
    }

    public virtual void SpawnEnemy(int spawnCount, params Action<Vector2>[] onDieEvents)
    {
        StartCoroutine(SpawnEnemyCorou(spawnCount, onDieEvents));
    }

    private IEnumerator SpawnEnemyCorou(int spawnCount, Action<Vector2>[] onDieEvents)
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < spawnCount; i++)
        {
            Enemy enemyPrefab = GetEnemy();
            if(enemyPrefab == null)
            {
                yield break;
            }
            Enemy spawnedEnemy = SpawnObject(enemyPrefab.name, Utils.GetRandomSpawnPos(_minBound.position, _maxBound.position)) as Enemy;
            spawnedEnemy.OnDieEvent = null;
            SubscribeEnemyDieEvent(spawnedEnemy);

            foreach (Action<Vector2> action in onDieEvents)
            {
                spawnedEnemy.OnDieEvent += action;
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.2f));
        }
    }

    protected virtual void SubscribeEnemyDieEvent(Enemy enemy)
    {
        enemy.OnDieEvent += _itemFactory.SpawnItem;
        enemy.OnDieEvent += _coinFactory.SpawnCoin;
        enemy.OnDieEvent += _ => _defaultWaveUI.UpdateUI();

        enemy.OnDieEvent += _ => WaveManager.Instance.IncreaseDeadEnemyCount();
    }

    protected virtual Enemy GetEnemy()
    {
        if(_spawnEntitys.Length < curEnemyType)
        {
            Debug.LogError($"{name} doesn't have {curEnemyType} Stage Enemy");
            return null;
        }

        return _spawnEntitys[curEnemyType - 1];
    }
}
