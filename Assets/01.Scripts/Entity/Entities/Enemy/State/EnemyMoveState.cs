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

        _entity.Move(GameManager.Instance.GetPlayerTrm().position);
    }

    public override void UpdateState()
    {
        bool isInRange = _entity.GetInRange(_entity.CheckRangeDistance).Item1;
        if (isInRange)
        {
            _entityStateMachine.ChangeState(EnemyStateType.Attack);
        }
    }
}