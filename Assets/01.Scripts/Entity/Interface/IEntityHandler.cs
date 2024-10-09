using System;

public interface IEntityHandler
{
    Entity<T, G> GetEntity<T, G>() where T : Enum where G : Entity<T, G>;
}
