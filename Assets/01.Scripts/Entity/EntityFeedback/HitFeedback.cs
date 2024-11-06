using UnityEngine;
using UnityEngine.Assertions.Must;

public class HitFeedback : Feedback
{
    public override void PlayFeedback<T, G>(IEntity owner)
    {
        
    }

    public override void PlayFeedback<T, G>(IEntity owner, TakeDamageInfo takeDamageInfo)
    {
        Entity<T, G> entity = owner.GetEntity<T,G>();
        
        Vector2 knockbackVec = (Vector2)(transform.position - takeDamageInfo.TriggerEntityPos).normalized;
        entity.StopImmediatetly();

        float knockbackPower =
            takeDamageInfo.KnockbackPower -
            Utils.CalculatePercent(takeDamageInfo.KnockbackPower, entity.EntityStatController.GetStatValue(StatType.ResistancePercent));

        entity.Rb.AddForce(knockbackVec * knockbackPower, ForceMode2D.Impulse);

        if(takeDamageInfo.HitFeedbackEffect != null) // TakeDamageInfo�� ��ӹ޴� skill ��¼���� ����ÿ�
        {
            Debug.Log(takeDamageInfo.HitFeedbackEffect.name);
            FeedbackEffect feedbackEffect = PoolManager.Instance.CreateObject(takeDamageInfo.HitFeedbackEffect.name) as FeedbackEffect;
            feedbackEffect.SetPosition(entity.transform.position); // �̰� ���� ��ġ��
        }

        CoroutineUtil.CallWaitForSeconds(0.1f, () => StopFeedback<T, G>(owner));
    }

    public override void StopFeedback<T, G>(IEntity owner)
    {
        Entity<T, G> entity = owner.GetEntity<T, G>();

        entity.Rb.velocity = Vector2.zero;
        
        if(entity.HP > 0)
        {
            entity.SetMove();
        }
    }
}
