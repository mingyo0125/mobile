using System;
using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void PlayFeedback<T, G>(IFeedbackPlayable<T, G> owner) where T : Enum where G : Entity<T,G>;
    public abstract void StopFeedback<T, G>(IFeedbackPlayable<T, G> owner) where T : Enum where G : Entity<T, G>;
}
