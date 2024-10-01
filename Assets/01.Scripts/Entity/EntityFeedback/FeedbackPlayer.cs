using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    public Dictionary<FeedbackTypes, Feedback> Feedbacks { get; private set; } = new Dictionary<FeedbackTypes, Feedback>();

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
    }

    public void PlayFeedback(FeedbackTypes feedbackType)
    {
        if(Feedbacks.TryGetValue(feedbackType, out Feedback feedback))
        {
            feedback.PlayFeedback();
        }
    }

    public void StopFeedback(FeedbackTypes feedbackType)
    {
        if (Feedbacks.TryGetValue(feedbackType, out Feedback feedback))
        {
            feedback.StopFeedback();
        }
    }
}
