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

    public float Speed { get; set; } // ���߿� SO��

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

    //     // isFacingRight�� right�� ���, �ƴϸ� left�� ���
    //    float dotProduct = Vector2.Dot(directionToTarget, IsFacingRight ? Vector2.right : Vector2.left);
    //    // ���� ����� �����̸� ������ �����ؾ� ��
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
