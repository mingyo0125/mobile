using UnityEngine;

public abstract partial class Entity<T, G> : IFeedbackPlayableEntity
{
    public FeedbackPlayer FeedbackPlayerCompo { get; set; }

    private void FeedbackAwake()
    {
        FeedbackPlayerCompo = transform.Find("FeedbackPlayer").GetComponent<FeedbackPlayer>();
    }
}