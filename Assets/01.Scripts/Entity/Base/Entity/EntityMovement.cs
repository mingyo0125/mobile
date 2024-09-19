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

    [field: SerializeField]
    public float Speed { get; set; } // ���߿� SO��

    private void InitializeMoveable()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 targetPos)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.fixedDeltaTime);
        Rb.MovePosition(newPosition);
        CheckFacingDir(targetPos);
    }

    public void CheckFacingDir(Vector2 moveDir)
    {
        
        // isFacingRight�� right�� ���, �ƴϸ� left�� ���
        float dotProduct = Vector2.Dot(moveDir, IsFacingRight ? Vector2.right : Vector2.left);

        // ���� ����� �����̸� ������ �����ؾ� ��
        if (dotProduct < 0f) { Flip(); }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;

        // �ϴ� �̷��� ȸ��
        transform.localScale *= -1;
    }
}
