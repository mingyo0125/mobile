using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageInfo
{
    public float Damage { get; private set; }
    public float KnockbackPower { get; private set; }
    public bool IsCritical { get; private set; }

    public Vector3 TriggerEntityPos { get; private set; }

    public TakeDamageInfo(float damage, float knockbackPower, bool isCritical, Vector2 triggerEntityPos)
    {
        KnockbackPower = knockbackPower;
        UpdateTakeDamageInfo(damage, isCritical, triggerEntityPos);
    }

    public void UpdateTakeDamageInfo(float damage, bool isCritical, Vector2 triggerEntityPos)
    {
        this.Damage = damage;
        this.IsCritical = isCritical;
        this.TriggerEntityPos = triggerEntityPos;
    }
}
