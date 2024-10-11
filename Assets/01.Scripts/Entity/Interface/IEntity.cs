using System;

public interface IEntity
{
    Entity<T, G> GetEntity<T, G>() where T : Enum where G : Entity<T, G>;
}
