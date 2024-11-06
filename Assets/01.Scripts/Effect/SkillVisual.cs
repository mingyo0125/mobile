using DG.Tweening;
using System;
using UnityEngine;

public class SkillVisual : MonoBehaviour, IMoveable
{
    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    public Rigidbody2D Rb { get; set; }

    [field: SerializeField]
    public float Speed { get; set; }

    public event Action OnAnimationEndEvent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        _spriteRenderer.color = Color.white;

        Move(transform.right);
    }

    public void StopImmediately()
    {
        Rb.velocity = Vector2.zero;
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
