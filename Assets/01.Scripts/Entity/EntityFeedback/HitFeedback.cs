using UnityEngine;
using UnityEngine.Assertions.Must;

public class HitFeedback : Feedback
{
    public override void PlayFeedback<T, G>(IFeedbackPlayable owner)
    {
        
    }

    public override void PlayFeedback<T, G>(IFeedbackPlayable owner, TakeDamageInfo takeDamageInfo)
    {
        Entity<T, G> entity = owner.GetEntity<T,G>();
        
        Vector2 knockbackVec = (Vector2)(transform.position - takeDamageInfo.TriggerEntityPos).normalized;
        entity.StopImmediatetly();
        entity.Rb.AddForce(knockbackVec * takeDamageInfo.KnockbackPower, ForceMode2D.Impulse);
        if (owner is Enemy)
        {
            Debug.Log("Knockback");
        }
        CoroutineUtil.CallWaitForSeconds(0.5f, () => StopFeedback<T, G>(owner));
    }

    public override void StopFeedback<T, G>(IFeedbackPlayable owner)
    {
        Entity<T, G> entity = owner.GetEntity<T, G>();

        entity.Rb.velocity = Vector2.zero;
        entity.SetMove();
    }
}
