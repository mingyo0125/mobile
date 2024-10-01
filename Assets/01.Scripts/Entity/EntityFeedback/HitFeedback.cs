using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : Feedback
{
    public override void PlayFeedback()
    {
        Debug.Log("Hit");
    }

    public override void StopFeedback()
    {
    }
}
