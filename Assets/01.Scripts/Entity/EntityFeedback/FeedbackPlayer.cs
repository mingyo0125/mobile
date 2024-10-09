using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    public Dictionary<FeedbackTypes, Feedback> Feedbacks { get; private set; } = new Dictionary<FeedbackTypes, Feedback>();

    protected IEntityHandler _owner;

    private void Awake()
    {
        foreach(FeedbackTypes feedbackType in Enum.GetValues(typeof(FeedbackTypes)))
        {
            Type type = Type.GetType($"{feedbackType}Feedback");

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                Component feedbackComponent = child.GetComponent(type);

                if (feedbackComponent != null)
                {
                    Feedbacks.Add(feedbackType, feedbackComponent as Feedback);
                }
            }
        }

        _owner = transform.parent.GetComponent<IEntityHandler>();
    }

    public void PlayFeedback<T, G>(FeedbackTypes feedbackType, TakeDamageInfo takeDamageInfo)
        where T : Enum where G : Entity<T, G>
    {
        if(Feedbacks.TryGetValue(feedbackType, out Feedback feedback))
        {
            feedback.PlayFeedback<T, G>(_owner, takeDamageInfo);
        }
    }

    public void PlayFeedback<T,G>(FeedbackTypes feedbackType)
        where T : Enum where G : Entity<T, G>
    {
        if (Feedbacks.TryGetValue(feedbackType, out Feedback feedback))
        {
            feedback.PlayFeedback<T, G>(_owner);
        }
    }

    public void StopFeedback<T,G>(FeedbackTypes feedbackType)
        where T : Enum where G : Entity<T, G>
    {
        if (Feedbacks.TryGetValue(feedbackType, out Feedback feedback))
        {
            feedback.StopFeedback<T,G>(_owner);
        }
    }
}
