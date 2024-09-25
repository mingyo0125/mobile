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

	public void Attack()
	{
		_animator.SetTrigger("AttackTrigger");
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
