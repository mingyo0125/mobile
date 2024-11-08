using DG.Tweening;
using System;
using UnityEngine;

public class SkillVisual : MonoBehaviour, IMoveable
{
    private SpriteRenderer _spriteRenderer;

    public Rigidbody2D Rb { get; set; }

    [field: SerializeField]
    public float Speed { get; set; }

    public event Action OnAnimationEndEvent;
    public event Func<bool> OnTakeDamageEvent;

    [SerializeField]
    private Vector2 _moveDir;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        _spriteRenderer.color = Color.white;

        Move(_moveDir);
    }

    public void StopImmediately()
    {
        Rb.velocity = Vector2.zero;
    }

    public void TakeDamageEvent()
    {
        OnTakeDamageEvent?.Invoke();
    }

    public void AnimationEndEvent()
    {
        OnAnimationEndEvent?.Invoke();
    }

    public void Move(Vector2 dir)
    {
        Rb.AddForce(dir * Speed, ForceMode2D.Impulse);
    }
}
