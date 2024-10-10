using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //���߿� SO�� ����
    public float CurrentHP { get; set; }
    public Collider2D EntityCollider { get; set; }

    public event Action<TakeDamageInfo> OnTakeDamagedEvent = null;
    public event Action<float, Color> OnHpChangedEvent = null;
	public event Action OnDieEvent = null;

    private Action DieAnimationEndEvent = null;

	private void HealthAwake()
    {
        MaxHP = _entityStatSO.EntityStat.MaxHP;

        DieAnimationEndEvent = FadeOut;
        EntityCollider = GetComponent<Collider2D>();
    }

    private void InitializeHealth()
    {
		CurrentHP = MaxHP;
        EnableCollider();

        OnHpChangedEvent += SpawnHudText;
        EntityAnimatorCompo.OnDieAnimationEndEvent += DieAnimationEndEvent;
        EntityAnimatorCompo.OnHitAnimationEndEvent += EnableCollider;
    }

    public virtual void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        Color hudTextColor = takeDamageInfo.IsCritical ? Color.red : Color.white;
        SetHp(-takeDamageInfo.Damage, hudTextColor);

        OnTakeDamagedEvent?.Invoke(takeDamageInfo);
        FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Hit, takeDamageInfo);
        EntityCollider.enabled = false;

        if (CurrentHP <= 0) { Die(); }
        else
        {
			EntityAnimatorCompo.SetFloat("Speed", -1f);
			EntityAnimatorCompo.SetTrigger("HitTrigger");
        }
    }

    public virtual void Die()
    {
		OnDieEvent?.Invoke();
        FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Die);
        EntityAnimatorCompo.SetFloat("Speed", -1f);
		EntityAnimatorCompo.SetTrigger("DieTrigger");
        StopImmediatetly();
    }

    public void SpawnHudText(float value, Color textColor)
    {
        HudText _hudText = PoolManager.Instance.CreateObject("HudText") as HudText;
        _hudText.transform.SetParent(transform);
        _hudText.SetPosition(transform.position + new Vector3(0, 0.1f, 0));
        _hudText.SpawnHudText(value, textColor);
    }

    public void SetHp(float value, Color hudTextColor)
    {
        CurrentHP += value;

        OnHpChangedEvent?.Invoke(value, hudTextColor);
    }

    private void EnableCollider()
    {
        EntityCollider.enabled = true;
    }

    private void HealthDisable()
    {
        OnHpChangedEvent -= SpawnHudText;
        EntityAnimatorCompo.OnDieAnimationEndEvent -= DieAnimationEndEvent;
        EntityAnimatorCompo.OnHitAnimationEndEvent -= EnableCollider;
    }
}
