using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFeedback : Feedback
{
    public override void PlayFeedback()
    {
        Debug.Log("Die");
    }

    public override void StopFeedback()
    {
    }
}