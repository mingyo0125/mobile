using System;
using System.Collections;
using Unity.Mathematics;
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

    public bool IsDead { get; private set; }

    public event Action<TakeDamageInfo> OnTakeDamagedEvent = null;
    public event Action<Vector2, string, Color> OnHpChangedEvent = null;
    public Action<Vector2> OnDieEvent { get; set; }

    public event Action OnDieAnimationEndEvent = null;

    public bool IsInvincibility { get; set; } = false;
    public Collider2D EntityCollider { get; set; }

    [Header("HpUI")]
    [SerializeField]
    protected EntityHpBar _entityHpBar;

    private void HealthAwake()
    {
        MaxHP = EntityStatController.GetStatValue(StatType.MaxHp);

        EntityCollider = GetComponent<Collider2D>();

    }

    private void InitializeHealth()
    {
		HP = MaxHP;
        
        _entityHpBar.UpdateMaxHp(MaxHP);
        _entityHpBar.ResetFillAmount();
        IsDead = false;

        EnableCollider();

        OnHpChangedEvent += UIManager.Instance.SpawnDamageText;
        OnDieAnimationEndEvent += FadeOut;
        EntityAnimatorCompo.OnDieAnimationEndEvent += OnDieAnimationEndEvent;
    }

    public virtual void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        if (IsDead) { return; }

        Color hudTextColor = takeDamageInfo.IsCritical ? Color.red : Color.white;
        SetHp(-takeDamageInfo.Damage, hudTextColor);

        OnTakeDamagedEvent?.Invoke(takeDamageInfo);
        FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Hit, takeDamageInfo);
        IsInvincibility = true;

        _entityHpBar.SetHpbarValue(HP);

        if (HP <= 0)
        {
            IsDead = true;
            Die();
        }
        else
        {
			EntityAnimatorCompo.SetFloat("Speed", -1f);
        }
    }

    public virtual void Die()
    {
        EntityCollider.enabled = false;

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

    public void EnableCollider()
    {
        EntityCollider.enabled = true;
        IsInvincibility = false;
    }

    private void HealthDisable()
    {
        OnHpChangedEvent = null;
        OnDieAnimationEndEvent = null;
       // OnDieEvent = null;

        EntityAnimatorCompo.OnDieAnimationEndEvent = null;
    }
}
