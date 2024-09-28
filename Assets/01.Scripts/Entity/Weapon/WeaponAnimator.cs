using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponAnimator : MonoBehaviour
{
	public event Action OnEndAttackEvent;
	public event Action OnAttackEvent;

    private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void SetAttackAnimation()
	{
		_animator.SetBool("AttackTrigger", true);
	}

	public void SetIdleAnimation()
	{
		_animator.SetBool("AttackTrigger", false);
	}

	public void EndAttackTrigger()
	{
		OnEndAttackEvent?.Invoke();
	}

	public void OnAttackTrigger()
	{
		OnAttackEvent?.Invoke();
	}
}
