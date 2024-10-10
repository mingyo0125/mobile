using UnityEngine;
using UnityEngine.Assertions.Must;

public class HitFeedback : Feedback
{
    public override void PlayFeedback<T, G>(IEntityHandler owner)
    {
        
    }

    public override void PlayFeedback<T, G>(IEntityHandler owner, TakeDamageInfo takeDamageInfo)
    {
        Entity<T, G> entity = owner.GetEntity<T,G>();
        
        Vector2 knockbackVec = (Vector2)(transform.position - takeDamageInfo.TriggerEntityPos).normalized;
        entity.StopImmediatetly();
        entity.Rb.AddForce(knockbackVec * takeDamageInfo.KnockbackPower, ForceMode2D.Impulse);
        CoroutineUtil.CallWaitForSeconds(0.1f, () => StopFeedback<T, G>(owner));
    }

    public override void StopFeedback<T, G>(IEntityHandler owner)
    {
        Entity<T, G> entity = owner.GetEntity<T, G>();

        entity.Rb.velocity = Vector2.zero;
        entity.SetMove();
    }
}
