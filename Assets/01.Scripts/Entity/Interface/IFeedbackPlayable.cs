using System;

public interface IFeedbackPlayable<T, G> where T : Enum where G : Entity<T, G>
{
    public FeedbackPlayer<T,G> FeedbackPlayerCompo { get; set; }

    Entity<T, G> GetEntity();
}
