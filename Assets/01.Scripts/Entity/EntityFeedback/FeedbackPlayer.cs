using System;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer<T, G> : MonoBehaviour where T : Enum where G : Entity<T, G>
{
    public Dictionary<FeedbackTypes, Feedback> Feedbacks { get; private set; } = new Dictionary<FeedbackTypes, Feedback>();

    protected IFeedbackPlayable<T,G> _owner;

    private void Awake()
    {
        foreach(FeedbackTypes feedbackType in Enum.GetValues(typeof(FeedbackTypes)))
        {
            Transform feedbackTrm = transform.Find($"{feedbackType}Feedback").transform;

            if(feedbackTrm != null)
            {
                Feedbacks.Add(feedbackType, feedbackTrm.GetComponent<Feedback>());
            }
            else
            {
                Debug.LogError($"FeedbackTypes: {feedbackType} is not Setting");
            }
        }

        _owner = transform.parent.GetComponent<IFeedbackPlayable<T,G>>();
    }

    public void PlayFeedback(FeedbackTypes feedbackType)
    {
        if(Feedbacks.TryGetValue(feedbackType, out Feedback feedback))
        {
            feedback.PlayFeedback(_owner);
        }
    }

    public void StopFeedback(FeedbackTypes feedbackType)
    {
        if (Feedbacks.TryGetValue(feedbackType, out Feedback feedback))
        {
            feedback.StopFeedback(_owner);
        }
    }
}
