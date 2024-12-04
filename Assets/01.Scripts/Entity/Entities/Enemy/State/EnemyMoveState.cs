using UnityEngine;

public class EnemyMoveState : EntityMoveState<EnemyStateType, Enemy>
{
    public EnemyMoveState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                          base(enemy, entityStateMachine)
    {
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        _owner.Move(Vector2.left);
    }

    public override void UpdateState()
    {
        if (GetAttackable())
        {
            _stateMachine.ChangeState(EnemyStateType.Attack);
        }
    }
}