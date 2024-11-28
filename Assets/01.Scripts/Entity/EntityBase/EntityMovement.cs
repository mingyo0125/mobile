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

    public float Speed { get; set; } // 나중에 SO로

    [field:SerializeField]
    public bool IsMove { get; private set; } = true;

	private void MovementAwake()
    {
        Rb = GetComponent<Rigidbody2D>();

	}

	private void InitializeMovement()
    {
		Speed = EntityStatController.GetStatValue(StatType.Speed);
        EntityAnimatorCompo.OnHitAnimationEndEvent += SetMove;
        SetMove();
	}

	public void Move(Vector2 dir)
    {
        if (!IsMove) { return; }

        Rb.velocity = dir * Speed;

        //CheckFacingDir(targetPos);
    }

    //public void CheckFacingDir(Vector2 targetPos)
    //{
    //    Vector2 directionToTarget = targetPos - (Vector2)transform.position;

    //     // isFacingRight면 right랑 계산, 아니면 left랑 계산
    //    float dotProduct = Vector2.Dot(directionToTarget, IsFacingRight ? Vector2.right : Vector2.left);
    //    // 내적 결과가 음수이면 방향을 반전해야 함
    //    if (dotProduct < 0f) { Flip(); }
    //}

    //private void Flip()
    //{
    //    IsFacingRight = !IsFacingRight;

    //    transform.Rotate(new Vector2(0, 180f));
    //}

    public void StopImmediatetly()
    {
        Rb.velocity = Vector2.zero;
        IsMove = false;
    }

    public void SetMove()
    {
        IsMove = true;
    }
}
