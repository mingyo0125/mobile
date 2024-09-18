using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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
        // isFacingRight면 right랑 계산, 아니면 left랑 계산
        float dotProduct = Vector2.Dot(moveDir, isFacingRight ? Vector2.right : Vector2.left);

        // 내적 결과가 음수이면 방향을 반전해야 함
        if (dotProduct < 0f) { Flip(); }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        // 일단 이렇게 회전
        transform.localScale *= -1;
    }
}
