using UnityEngine;

public class EnemyMoveState : EntityMoveState<EnemyStateType, Enemy>
{
    public EnemyMoveState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                          base(enemy, entityStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        _entity.Move(GameManager.Instance.GetPlayerTrm().position);
    }
}