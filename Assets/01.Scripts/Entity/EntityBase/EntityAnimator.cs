using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Action OnHitAnimationEndEvent = null;
    public Action OnDieAnimationEndEvent = null;
    public Action OnAttackAnimationEvent = null;

    private Animator _animator;
    public Animator AnimatorCompo => _animator;

    private const float originSpeed = 1;

    private const string AttackTrigger = "AttackTrigger";

    private Queue<string> _attackAnimationTriggerQueue = new Queue<string>();
    private Dictionary<string, Action> _attackAnimationEvents =
            new Dictionary<string, Action>();

    private bool isAnimationPlaying = false; // 현재 애니메이션 실행 여부 확인용
    private string nextAniamtionName;

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
        _animator.SetFloat("AttackSpeed", speed);
        _animator.SetTrigger(animationName);
    }

    public void QueueSkillAnimationTrigger(string key, float speed = 1, Action action = null)
    {
        _attackAnimationTriggerQueue.Enqueue(key);

        if(action != null &&
           !_attackAnimationEvents.ContainsKey(key))
        {
            _attackAnimationEvents.Add(key, action);
        }

        _animator.SetFloat("AttackSpeed", 1f / speed);

        if (!isAnimationPlaying)
        {
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        isAnimationPlaying = true;
        _animator.SetTrigger(AttackTrigger); // 다음 애니메이션 실행
    }

    public void EndAttackEventTrigger()
    {
        if (_attackAnimationTriggerQueue.Count > 0) // 큐에 값이 있다면
        {
            PlayAttackAnimation(); // 다음 애니메이션 실행
        }
        else
        {
            EndAttack();
        }
    }

    protected virtual void EndAttack()
    {
        isAnimationPlaying = false;
    }

    public void EndHitEventTrigger()
    {
        _animator.speed = originSpeed;
        OnHitAnimationEndEvent?.Invoke();
	}

	public void EndDieEventTrigger()
	{
        _animator.speed = originSpeed;
        OnDieAnimationEndEvent?.Invoke();
	}


    public void AttackEventTrigger()
    {
        nextAniamtionName = _attackAnimationTriggerQueue.Dequeue();

        if(_attackAnimationEvents.TryGetValue(nextAniamtionName, out Action action))
        {
            action?.Invoke();
            _attackAnimationEvents.Remove(nextAniamtionName);
        }

        OnAttackAnimationEvent?.Invoke();
    }

    private void OnDisable()
    {
        _attackAnimationEvents.Clear();
        _attackAnimationTriggerQueue.Clear();
        isAnimationPlaying = false;
    }
}