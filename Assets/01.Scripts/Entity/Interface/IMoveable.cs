using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public Rigidbody2D Rb { get; set; }

    public bool IsFacingRight { get; set; }
    public float Speed { get; set; }

    public void Move(Vector2 moveVelocity);
    public void CheckFacingDir(Vector2 dir);
}
