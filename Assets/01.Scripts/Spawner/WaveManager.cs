using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoSingleTon<WaveManager>
{
    [SerializeField]
    private EnemyFactory _enemyFactory;
    [SerializeField]
    private BossFactory _bossFactory;

    [SerializeField]
    private int spawnedEnmiesCount;

    [SerializeField]
    private int deadEnmiesCount;

    public int CurStageCount { get; private set; } = 1;
    public int CurWaveCount { get; private set; }

    private const int bossWaveNumber = 2;

    private void Start()
    {
        _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
    }

    public void IncreaseDeadEnemyCount()
    {
        deadEnmiesCount++;

        if (deadEnmiesCount == spawnedEnmiesCount)
        {
            deadEnmiesCount = 0;
            CurWaveCount++;

            //if (CurWaveCount % bossWaveNumber == 0)
            //{
            //    SpawnBoss();
            //}

            _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
        }
    }

    public void StageClear()
    {
        CurStageCount++;
        deadEnmiesCount = 0;
        CurWaveCount = 1;

        Debug.Log("Stage Clear");
    }

    public void SpawnBossWarningPanel()
    {
        // ���߿� Signalhub delegate�� ó�� later
        BossWarningPanel bossWarningPanel = UIManager.Instance.CreateUI("BossWarningPanel", null, UIGenerateType.NONE, UIGenerateSortType.TOP) as BossWarningPanel;
        bossWarningPanel.UpdateUI();
        _bossFactory.SpawnEnemy(spawnedEnmiesCount);
        return;
    }
}
