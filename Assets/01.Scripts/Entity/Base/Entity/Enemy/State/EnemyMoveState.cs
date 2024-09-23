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

        Debug.Log(_entity.gameObject.name);
        _entity.EntityAnimatorCompo.SetFloat("Speed", _entity.Speed);
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        _entity.Move(GameManager.Instance.GetPlayerTrm().position);
    }
}