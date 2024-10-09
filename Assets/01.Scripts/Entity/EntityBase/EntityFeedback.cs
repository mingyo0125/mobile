using System;
using UnityEngine;

public abstract partial class Entity<T, G> : IFeedbackPlayable
{
    public FeedbackPlayer FeedbackPlayerCompo { get; set; }

    public Entity<T1, G1> GetEntity<T1, G1>()
        where T1 : Enum
        where G1 : Entity<T1, G1>
    {
        return this as G1;
    }

    private void FeedbackAwake()
    {
        FeedbackPlayerCompo = transform.Find("FeedbackPlayer").GetComponent<FeedbackPlayer>();
    }
}