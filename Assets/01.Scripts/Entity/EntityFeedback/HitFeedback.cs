using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : Feedback
{
    public override void PlayFeedback<T, G>(IFeedbackPlayable<T, G> owner)
    {
        Entity<T, G> entity = owner.GetEntity();

    }

    public override void StopFeedback<T, G>(IFeedbackPlayable<T, G> owner)
    {
    }
}
