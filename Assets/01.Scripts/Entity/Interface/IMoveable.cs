using UnityEngine;

public interface IMoveable
{
    public Rigidbody2D Rb { get; set; }

    public float Speed { get; set; }

    public void Move(Vector2 dir);
}
