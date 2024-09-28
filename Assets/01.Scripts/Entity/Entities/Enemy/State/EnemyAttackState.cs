public class EnemyAttackState : EntityAttackState<EnemyStateType, Enemy>
{
    public EnemyAttackState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                            base(enemy, entityStateMachine)
    {
    }

	public override void ChangeIdleState()
	{
		_entityStateMachine.ChangeState(EnemyStateType.Idle);
	}
}
