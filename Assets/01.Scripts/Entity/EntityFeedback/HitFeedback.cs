using UnityEngine;

public class HitFeedback : Feedback
{
    public override void PlayFeedback<T, G>(IFeedbackPlayable owner)
    {
        
    }

    public override void PlayFeedback<T, G>(IFeedbackPlayable owner, TakeDamageInfo takeDamageInfo)
    {
        Entity<T, G> entity = owner.GetEntity<T,G>();
        //Vector2 knockbackVec = (Vector2)(transform.position - takeDamageInfo.TriggerEntityPos).normalized;
        //entity.Rb.AddForce(knockbackVec * takeDamageInfo.KnockbackPower);
    }

    public override void StopFeedback<T, G>(IFeedbackPlayable owner)
    {
    }
}
