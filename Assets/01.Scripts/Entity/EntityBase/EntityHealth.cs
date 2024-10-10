using System;
using UnityEngine;

public abstract partial class Entity<T, G> : IDamageable
{
    public float MaxHP { get; set; }      //나중에 SO로 빼기
    public float CurrentHP { get; set; }
    public Collider2D EntityCollider { get; set; }

    public event Action<TakeDamageInfo> OnTakeDamagedEvent = null;
	public event Action OnDieEvent = null;

    private Action DieAnimationEndEvent = null;

	private void HealthAwake()
    {
        MaxHP = _entityStatSO.EntityStat.MaxHP;

        DieAnimationEndEvent = () => PoolManager.Instance.DestroyObject(this);
        EntityCollider = GetComponent<Collider2D>();
    }

    private void InitializeHealth()
    {
		CurrentHP = MaxHP;
        EnableCollider();
        OnTakeDamagedEvent += SpawnHudText;
        EntityAnimatorCompo.OnDieAnimationEndEvent += DieAnimationEndEvent;
        EntityAnimatorCompo.OnHitAnimationEndEvent += EnableCollider;
    }

    public virtual void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        OnTakeDamagedEvent?.Invoke(takeDamageInfo);
        FeedbackPlayerCompo.PlayFeedback<T, G>(FeedbackTypes.Hit, takeDamageInfo);
        EntityCollider.enabled = false;
        CurrentHP -= takeDamageInfo.Damage;
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
	}

    private void SpawnHudText(TakeDamageInfo takeDamageInfo)
    {
        HudText _hudText = PoolManager.Instance.CreateObject("HudText") as HudText;
        _hudText.transform.SetParent(transform);
        _hudText.SetPosition(transform.position + new Vector3(0, 0.1f, 0));
        _hudText.SpawnHudText(takeDamageInfo.IsCritical, takeDamageInfo.Damage);
    }

    private void EnableCollider()
    {
        if (this is Player)
        {
            Debug.Log("EnableCollider");
        }

        EntityCollider.enabled = true;
    }

    private void HealthDisable()
    {
        OnTakeDamagedEvent -= SpawnHudText;
        EntityAnimatorCompo.OnDieAnimationEndEvent -= DieAnimationEndEvent;
        EntityAnimatorCompo.OnHitAnimationEndEvent -= EnableCollider;
    }
}
