using System;
using UnityEngine;

public abstract partial class Entity<T, G> : IFeedbackPlayable
{
    public FeedbackPlayer FeedbackPlayerCompo { get; set; }


    public Entity<T, G> GetEntity<T, G>()
        where T : Enum
        where G : Entity<T, G>
    {
        return this as G;
    }

    private void FeedbackAwake()
    {
        FeedbackPlayerCompo = transform.Find("FeedbackPlayer").GetComponent<FeedbackPlayer>();
    }
}