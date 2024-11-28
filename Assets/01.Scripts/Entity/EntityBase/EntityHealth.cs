using System;
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
    public event Action<Vector2, string, Color> OnHpChangedEvent = null;
    public Action<Vector2> OnDieEvent { get; set; }

    public event Action OnDieAnimationEndEvent = null;

    [Header("HpUI")]
    [SerializeField]
    private EntityHpBar _entityHpBar;

    private void HealthAwake()
    {
        MaxHP = EntityStatController.GetStatValue(StatType.MaxHp);

        EntityCollider = GetComponent<Collider2D>();

        _entityHpBar.UpdateMaxHp(MaxHP);
    }

    private void InitializeHealth()
    {
		HP = MaxHP;
        _entityHpBar.ReserFillAmount();

        EnableCollider();

        OnHpChangedEvent += UIManager.Instance.SpawnDamageText;
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

        _entityHpBar.SetHpbarValue(HP);

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

        OnHpChangedEvent?.Invoke((Vector2)transform.position + new Vector2(0, 0.1f), GetHudTextValue(value), hudTextColor);
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
       // OnDieEvent = null;

        EntityAnimatorCompo.OnDieAnimationEndEvent = null;
        EntityAnimatorCompo.OnHitAnimationEndEvent = null;
    }
}
