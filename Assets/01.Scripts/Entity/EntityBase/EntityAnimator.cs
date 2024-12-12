using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAnimator : MonoBehaviour
{
    public Action OnDieAnimationEndEvent = null;
    public Action OnAttackEvent = null;

    private Animator _animator;
    public Animator AnimatorCompo => _animator;

    private const float originSpeed = 1;

    private const string AttackTrigger = "AttackTrigger";

    protected bool isAnimationPlaying = false; // 현재 애니메이션 실행 여부 확인용

    protected IEntity _owner;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _owner = transform.parent.GetComponent<IEntity>();
    }

    public void SetFloat(string animationName, float value)
    {
        _animator.SetFloat(animationName, value);
    }

    public void SetTrigger(string animationName, float speed = 1)
    {
        isAnimationPlaying = true;
        _animator.SetFloat("AttackSpeed", speed);
        _animator.SetTrigger(animationName);
    }

    protected void PlayAttackAnimation()
    {
        isAnimationPlaying = true;
        _animator.SetTrigger(AttackTrigger); // 다음 애니메이션 실행
    }

    public virtual void EndAttackEventTrigger()
    {
        EndAttack();
    }

    protected virtual void EndAttack()
    {
        isAnimationPlaying = false;
    }

	public void EndDieEventTrigger()
	{
        _animator.speed = originSpeed;
        OnDieAnimationEndEvent?.Invoke();
	}


    public virtual void AttackEventTrigger()
    {
        OnAttackEvent?.Invoke();
    }

    protected virtual void OnDisable()
    {
        isAnimationPlaying = false;
    }
}