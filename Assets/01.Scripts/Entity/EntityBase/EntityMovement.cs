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

    public float Speed { get; set; } // ���߿� SO��

    private void InitializeMovement()
    {
        Rb = GetComponent<Rigidbody2D>();
          
        Speed = _entityStatSO.EntityStat.Speed;

        EntityAnimatorCompo.OnHitAnimationEndEvent += EndHitAnimationEvent;
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

         // isFacingRight�� right�� ���, �ƴϸ� left�� ���
        float dotProduct = Vector2.Dot(directionToTarget, IsFacingRight ? Vector2.right : Vector2.left);
        // ���� ����� �����̸� ������ �����ؾ� ��
        if (dotProduct < 0f) { Flip(); }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;

        // �ϴ� �̷��� ȸ��
        transform.Rotate(new Vector2(0, 180f));
    }

    private void EndHitAnimationEvent()
    {
		EntityAnimatorCompo.SetFloat("Speed", Speed);
	}
}