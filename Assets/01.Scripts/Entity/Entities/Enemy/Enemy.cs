using UnityEngine;

public class Enemy : Entity<EnemyStateType, Enemy>
{
    [Space]
    [SerializeField]
    private EnemyStatSO _enemyStatSO;

    protected sealed override BaseStat GetStatSO()
    {
        if (_enemyStatSO.EnemyStat != null)
        {
            return _enemyStatSO.EnemyStat;
        }
        return null;
    }

    public override void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        base.TakedDamage(takeDamageInfo);

        StateMachine.ChangeState(EnemyStateType.Idle);
    }

    protected override void CreateStateMachine()
    {
        StateMachine = new EnemyStateMachine(this);
    }

    protected override void SetStat()
    {
        EnemyStat enemyStat = new EnemyStat(_enemyStatSO.EnemyStat);
        EntityStatController.Initialize(enemyStat);
    }

    protected override string GetHudTextValue(float value)
    {
        return $"{-value}";
    }

    protected override void OnDisable()
    {
        EntityStatController.ResetStat();
        base.OnDisable();

    }
}
