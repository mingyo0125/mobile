using System;

public class EntityIdleState<T,G> : EntityState<T,G> where T: Enum where G: Entity<T, G>
{
    public EntityIdleState(G entity, EntityStateMachine<T, G> entityStateMachine):
                           base(entity, entityStateMachine)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        //Debug.Log($"{_entity}: UpdateState");
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

        //Debug.Log($"{_entity}: FixedUpdateState");
    }
}
