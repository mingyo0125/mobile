using UnityEngine;

public abstract partial class Entity<T, G> : IFeedbackPlayable<T,G>
{
    public FeedbackPlayer<T,G> FeedbackPlayerCompo { get; set; }

    FeedbackPlayer<T, G> IFeedbackPlayable<T, G>.FeedbackPlayerCompo { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Entity<T, G> GetEntity()
    {
        return this;
    }

    private void FeedbackAwake()
    {
        FeedbackPlayerCompo = transform.Find("FeedbackPlayer").GetComponent<FeedbackPlayer<T, G>>();
    }
}