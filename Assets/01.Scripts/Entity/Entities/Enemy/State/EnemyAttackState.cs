using UnityEngine;

public class EnemyAttackState : EntityAttackState<EnemyStateType, Enemy>
{
    public EnemyAttackState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                            base(enemy, entityStateMachine)
    {
        
    }

	public override void ChangeNextState()
	{
		_stateMachine.ChangeState(EnemyStateType.Move);
	}

    protected override void Attack()
    {
        foreach (Collider2D item in GetInRange(_owner.EntityStatController.GetStatValue(StatType.AttackRange)).Item2)
        {
            if (item.TryGetComponent(out IDamageable component))
            {
                if (component.IsInvincibility) { return; }
                Vector2 hitPoint = component.EntityCollider.ClosestPoint(_owner.transform.position);
                component.TakedDamage(_owner.GetTakeDamageInfo(hitPoint));
            }
            else
            {
                Debug.Log($"{component} not have IDamageable");
            }
        }
    }
}
