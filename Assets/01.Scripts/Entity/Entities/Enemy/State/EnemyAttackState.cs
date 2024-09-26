public class EnemyAttackState : EntityAttackState<EnemyStateType, Enemy>
{
    public EnemyAttackState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                            base(enemy, entityStateMachine)
    {
    }

	public override void ChangeMoveState()
	{
		_entityStateMachine.ChangeState(EnemyStateType.Move);
	}
}
