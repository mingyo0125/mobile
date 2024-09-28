using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public abstract partial class Entity<T, G> : IMoveable
{
    public Rigidbody2D Rb { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public float Speed { get; set; } // 나중에 SO로

    private Action _endHitAnimationEvent;

	private void MovementAwake()
    {
        Rb = GetComponent<Rigidbody2D>();
		_endHitAnimationEvent = EndHitAnimationEvent;
	}

	private void InitializeMovement()
    {
        IsFacingRight = true;
		Speed = _entityStatSO.EntityStat.Speed;

		EntityAnimatorCompo.OnHitAnimationEndEvent += _endHitAnimationEvent;
	}

	public void Move(Vector2 targetPos)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.fixedDeltaTime);
        Rb.MovePosition(newPosition);
        CheckFacingDir(targetPos);
    }

    public void CheckFacingDir(Vector2 targetPos)
    {
        Vector2 directionToTarget = targetPos - (Vector2)transform.position;

         // isFacingRight면 right랑 계산, 아니면 left랑 계산
        float dotProduct = Vector2.Dot(directionToTarget, IsFacingRight ? Vector2.right : Vector2.left);
        // 내적 결과가 음수이면 방향을 반전해야 함
        if (dotProduct < 0f) { Flip(); }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;

        // 일단 이렇게 회전
        transform.Rotate(new Vector2(0, 180f));
    }

    private void EndHitAnimationEvent()
    {
		EntityAnimatorCompo.SetFloat("Speed", Speed);
	}

    private void MovemetDisable()
    {
		EntityAnimatorCompo.OnHitAnimationEndEvent -= _endHitAnimationEvent;
	}
}
