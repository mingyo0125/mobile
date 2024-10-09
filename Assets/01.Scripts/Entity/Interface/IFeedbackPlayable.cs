using System;

public interface IFeedbackPlayable
{
    public FeedbackPlayer FeedbackPlayerCompo { get; set; }

    Entity<T, G> GetEntity<T, G>() where T : Enum where G : Entity<T, G>;
}
