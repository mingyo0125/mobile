using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageInfo
{
    public float Damage { get; private set; }
    public float KnockbackPower { get; private set; }
    public bool IsCritical { get; private set; }

    public Vector3 TriggerEntityPos { get; private set; }

    public FeedbackEffect HitFeedbackEffect { get; private set; }

    public void UpdateTakeDamageInfo(float damage,float knockbackPower, bool isCritical, Vector2 triggerEntityPos)
    {
        this.Damage = damage;
        this.KnockbackPower = knockbackPower;
        this.IsCritical = isCritical;
        this.TriggerEntityPos = triggerEntityPos;
    }

    public void UpdateHitFeedbackEffect(FeedbackEffect hitFeedbackEffect)
    {
        this.HitFeedbackEffect = hitFeedbackEffect;
    }
}
