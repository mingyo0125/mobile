using System;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public event Action OnHitAnimationEndEvent = null;

    private Animator _animator;
    public Animator AnimatorCompo => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetFloat(string AnimationName, float value)
    {
        _animator.SetFloat(AnimationName, value);
    }

    public void SetTrigger(string AnimationName)
    {
		_animator.SetTrigger(AnimationName);
	}

    public void EndHitEventTrigger()
    {
		OnHitAnimationEndEvent?.Invoke();
	}
}