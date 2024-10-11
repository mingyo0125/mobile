using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //나중에 SO로 빼기

    private float currentHp;

    public float HP
    {
        get => currentHp;
        set
        {
            currentHp = Mathf.Clamp(value, 0, MaxHP);
        }
    }
    public Collider2D EntityCollider { get; set; }

    public event Action<TakeDamageInfo> OnTakeDamagedEvent = null;
    public event Action<Transform, string, Color> OnHpChangedEvent = null;
    public Action<Vector2> OnDieEvent {get; set;}

    public event Action OnDieAnimationEndEvent = null;

	private void HealthAwake()
    {
        MaxHP = EntityStat.MaxHP;

        EntityCollider = GetComponent<Collider2D>();
    }

    private void InitializeHealth()
    {
		HP = MaxHP;
        EnableCollider();

        //OnDieEvent = null;
        OnHpChangedEvent += UIManager.Instance.SpawnHudText;
        OnDieAnimationEndEvent += FadeOut;
        EntityAnimatorCompo.OnDieAnimationEndEvent += OnDieAnimationEndEvent;
        EntityAnimatorCompo.OnHitAnimationEndEvent += EnableCollider;
    }

    public virtual void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        Color hudTextColor = takeDamageInfo.IsCritical ? Color.red : Color.white;
        SetHp(-takeDamageInfo.Damage, hudTextColor);

        OnTakeDamagedEvent?.Invoke(takeDamageInfo);
        FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Hit, takeDamageInfo);
        EntityCollider.enabled = false;

        if (HP <= 0) { Die(); }
        else
        {
			EntityAnimatorCompo.SetFloat("Speed", -1f);
			EntityAnimatorCompo.SetTrigger("HitTrigger");
        }
    }

    public virtual void Die()
    {
		OnDieEvent?.Invoke(transform.position);
        FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Die);
        EntityAnimatorCompo.SetFloat("Speed", -1f);
		EntityAnimatorCompo.SetTrigger("DieTrigger");
        StopImmediatetly();
    }

    

    public void SetHp(float value, Color hudTextColor)
    {
        HP += value;

        OnHpChangedEvent?.Invoke(transform, GetHudTextValue(value), hudTextColor);
    }

    protected abstract string GetHudTextValue(float value);

    private void EnableCollider()
    {
        EntityCollider.enabled = true;
    }

    private void HealthDisable()
    {
        OnHpChangedEvent = null;
        OnDieAnimationEndEvent = null;
        EntityAnimatorCompo.OnDieAnimationEndEvent -= OnDieAnimationEndEvent;
        EntityAnimatorCompo.OnHitAnimationEndEvent -= EnableCollider;
    }
}
