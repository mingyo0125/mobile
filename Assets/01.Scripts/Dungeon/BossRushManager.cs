using UnityEngine;

// 나중에 던전 여러개 생기면 추상화 해서
public class BossRushManager : MonoSingleTon<BossRushManager>
{
    [SerializeField]
    private BossRushEnemyFactory _bossRushEnemyFactory;

    private int deadBossRushEnmiesCount;
    private int curLevel = 1;

    private void Start()
    {
        Signalhub.OnEndBossRushEventEvent += WaveManager.Instance.SpawnEnemy;
    }

    public void StartBossRush()
    {
        deadBossRushEnmiesCount = 0;
        WaveManager.Instance.ResetWave();
        _bossRushEnemyFactory.SpawnEnemy(1);
    }

    public void IncreaseBossRushDeadEnemyCount()
    {
        deadBossRushEnmiesCount++;
        
        if (deadBossRushEnmiesCount == 1)
        {
            UIManager.Instance.RemoveTopUGUI();
            UIManager.Instance.CreateUI("BossRushClearPanel", Vector2.zero, null, UIGenerateType.STACKING, UIGenerateSortType.TOP).UpdateUI();
            return;
        }

        _bossRushEnemyFactory.SpawnEnemy(1);
    }

    public int GetRewardValue()
    {
        return 500 + (GetCurLevel() - 1) * 10;
    }

    public int GetCurLevel()
    {
        return curLevel;
    }

    public void SetCurLevel(int level)
    {
        curLevel = level;
    }
}
