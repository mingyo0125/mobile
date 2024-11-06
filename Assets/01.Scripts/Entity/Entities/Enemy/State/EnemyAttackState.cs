using UnityEngine;

public class EnemyAttackState : EntityAttackState<EnemyStateType, Enemy>
{
    public EnemyAttackState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                            base(enemy, entityStateMachine)
    {
        
    }

	public override void ChangeMoveState()
	{
		_stateMachine.ChangeState(EnemyStateType.Move);
	}

    protected override void TakeDamage()
    {
        foreach (Collider2D item in GetInRange(_owner.EntityStatController.GetStatValue(StatType.AttackRange)).Item2)
        {
            if (item.TryGetComponent(out IDamageable component))
            {
                component.TakedDamage(_owner.GetTakeDamageInfo());
            }
            else
            {
                Debug.Log($"{component} not have IDamageable");
            }
        }
    }
}
