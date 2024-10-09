using UnityEngine;

public class Enemy : Entity<EnemyStateType, Enemy>
{
    protected override void OnEnable()
    {
        base.OnEnable();
        OnTakeDamagedEvent += SpawnHudText;
    }

    private void SpawnHudText(TakeDamageInfo takeDamageInfo)
    {
        HudText _hudText = PoolManager.Instance.CreateObject("HudText") as HudText;
        _hudText.transform.SetParent(transform);
        _hudText.SetPosition(transform.position + new Vector3(0, 0.1f, 0));
        _hudText.SpawnHudText(takeDamageInfo.IsCritical, takeDamageInfo.Damage);
    } 

    protected override void CreateStateMachine()
    {
        StateMachine = new EnemyStateMachine(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        OnTakeDamagedEvent -= SpawnHudText;
    }
}
