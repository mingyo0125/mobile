using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Entity<T, G> : IMoveable
{
    public Rigidbody2D Rb { get; set; }
    public bool isFacingRight { get; set; } = true;

    private void InitializeMoveable()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveVelocity)
    {
        Rb.velocity = moveVelocity;
        CheckFacingDir(moveVelocity);
    }

    public void CheckFacingDir(Vector2 moveDir)
    {
        // isFacingRight�� right�� ���, �ƴϸ� left�� ���
        float dotProduct = Vector2.Dot(moveDir, isFacingRight ? Vector2.right : Vector2.left);

        // ���� ����� �����̸� ������ �����ؾ� ��
        if (dotProduct < 0f) { Flip(); }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        // �ϴ� �̷��� ȸ��
        transform.localScale *= -1;
    }
}
