using UnityEngine;

public class EnemyAttackState : EntityAttackState<EnemyStateType, Enemy>
{
    public EnemyAttackState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                            base(enemy, entityStateMachine)
    {
        
    }

	public override void ChangeIdleState()
	{
		_stateMachine.ChangeState(EnemyStateType.Idle);
	}

    protected override void TakeDamage()
    {
        base.TakeDamage();

        foreach (Collider2D item in GetInRange(_owner.EntityStat.AttackRange).Item2)
        {
            if (item.TryGetComponent(out IDamageable component))
            {

                component.TakedDamage(_owner.EntityTakeDamageInfo);
            }
            else
            {
                Debug.Log($"{component} not have IDamageable");
            }
        }
    }
}
