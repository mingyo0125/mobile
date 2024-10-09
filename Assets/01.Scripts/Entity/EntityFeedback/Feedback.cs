using System;
using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void PlayFeedback<T, G>(IEntityHandler owner) where T : Enum where G : Entity<T,G>;
    public virtual void PlayFeedback<T, G>(IEntityHandler owner, TakeDamageInfo takeDamageInfo) where T : Enum where G : Entity<T, G> { }
    
    public abstract void StopFeedback<T, G>(IEntityHandler owner) where T : Enum where G : Entity<T, G>;
}
