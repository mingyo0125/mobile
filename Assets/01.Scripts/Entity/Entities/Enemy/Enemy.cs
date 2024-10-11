using UnityEngine;

public class Enemy : Entity<EnemyStateType, Enemy>
{
    [SerializeField]
    private EnemyStatSO _enemyStatSO;

    protected override BaseStat GetStat()
    {
        if (_enemyStatSO.EnemyStat != null)
        {
            return _enemyStatSO.EnemyStat;
        }
        return null;
    }

    protected override void CreateStateMachine()
    {
        StateMachine = new EnemyStateMachine(this);
    }

    protected override void SetStat()
    {
        EntityStat = _enemyStatSO.EnemyStat;
    }

    protected override string GetHudTextValue(float value)
    {
        return $"{-value}";
    }
}
