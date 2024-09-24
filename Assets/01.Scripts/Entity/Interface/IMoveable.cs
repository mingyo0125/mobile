using UnityEngine;

public interface IMoveable
{
    public Rigidbody2D Rb { get; set; }

    public bool IsFacingRight { get; set; }
    public float Speed { get; set; }

    public void Move(Vector2 targetPos);
    public void CheckFacingDir(Vector2 dir);
}
