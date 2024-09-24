using System;

public class EntityIdleState<T,G> : EntityState<T,G> where T: Enum where G: Entity<T, G>
{
    public EntityIdleState(G entity, EntityStateMachine<T, G> entityStateMachine):
                           base(entity, entityStateMachine)
    {
    }
}
