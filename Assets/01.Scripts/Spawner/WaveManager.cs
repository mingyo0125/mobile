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

    private const int bossWaveNumber = 2;

    private const string stageClearPanelName = "ClearPanel";

    private void Start()
    {
        SpawnEnemy();
    }

    public void IncreaseDeadEnemyCount()
    {
        deadEnmiesCount++;

        if (deadEnmiesCount == spawnedEnmiesCount)
        {
            deadEnmiesCount = 0;

            //if (CurWaveCount % bossWaveNumber == 0)
            //{
            //    SpawnBoss();
            //}

            _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
        }
    }

    public void SpawnEnemy()
    {
        _enemyFactory.SpawnEnemy(spawnedEnmiesCount);
    }

    public void ResetWave()
    {
        ResetEnemies();
        ResetSkills();
    }

    private void ResetEnemies()
    {
        Object[] enemies = FindObjectsByType(typeof(Enemy), FindObjectsSortMode.None);
        foreach (var enemy in enemies)
        {
            PoolManager.Instance.DestroyObject(enemy as Enemy);
        }

        deadEnmiesCount = 0;

        //_enemyFactory.SpawnEnemy(spawnedEnmiesCount);
    }

    private void ResetSkills()
    {
        Object[] skills = FindObjectsByType(typeof(BaseSkill), FindObjectsSortMode.None);
        foreach (var skill in skills)
        {
            PoolManager.Instance.DestroyObject(skill as BaseSkill);
        }
    }

    public void EndStage(bool isClear)
    {
        deadEnmiesCount = 0;

        if (isClear)
        {
            CurStageCount++;
            StageClearPanel stageClearPanel = UIManager.Instance.CreateUI(stageClearPanelName, Vector2.zero, null, UIGenerateType.NONE, UIGenerateSortType.TOP) as StageClearPanel;
            stageClearPanel.UpdateUI();

            Debug.Log("Stage Clear");
        }
        else
        {
            ResetWave();
        }
    }


    public void SpawnBossWarningPanel()
    {
        BossWarningPanel bossWarningPanel = UIManager.Instance.CreateUI("BossWarningPanel", Vector2.zero, null, UIGenerateType.NONE, UIGenerateSortType.TOP) as BossWarningPanel;
        bossWarningPanel.UpdateUI();
        _bossFactory.SpawnEnemy(spawnedEnmiesCount);
        return;
    }
}
