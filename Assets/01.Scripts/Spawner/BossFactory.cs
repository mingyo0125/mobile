
public class BossFactory : EnemyFactory
{
    private BossTimeLimitUI _bossTimeLimitUI;

    protected override void Awake()
    {
        base.Awake();
        _bossTimeLimitUI = FindAnyObjectByType<BossTimeLimitUI>();
    }

    protected override void SubscribeEnemyDieEvent(Enemy enemy)
    {
        base.SubscribeEnemyDieEvent(enemy);

        enemy.OnDieEvent += _ => WaveManager.Instance.EndStage(true);
        enemy.OnDieEvent += _ => _bossTimeLimitUI.StopUpdateTimeLimitUICoroutine();

        Player player = GameManager.Instance.GetPlayer();
        player.OnDieEvent += _ => WaveManager.Instance.EndStage(false);
        player.OnDieEvent += _ => _bossTimeLimitUI.StopUpdateTimeLimitUICoroutine();
        player.OnDieEvent += _ => Signalhub.OnStageClearEvent?.Invoke(false);

        _bossTimeLimitUI.UpdateUI();
    }
}
