using System;
using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void PlayFeedback<T, G>(IEntity owner) where T : Enum where G : Entity<T,G>;
    public virtual void PlayFeedback<T, G>(IEntity owner, TakeDamageInfo takeDamageInfo) where T : Enum where G : Entity<T, G> { }
    
    public abstract void StopFeedback<T, G>(IEntity owner) where T : Enum where G : Entity<T, G>;
}
