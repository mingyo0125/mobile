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

    [SerializeField]
    private bool isMoving;

    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        if (!isMoving) { return; }
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        _spriteRenderer.color = Color.white;

        if (!isMoving) { return; }
        Move(_moveDir);
    }

    public void StopImmediately()
    {
        if (!isMoving) { return; }
        isMoving = false;
        Rb.velocity = Vector2.zero;
    }

    public void SetMove()
    {
        isMoving = true;
        Move(_moveDir);
    }

    public void TakeDamageEvent()
    {
        OnTakeDamageEvent?.Invoke();
    }

    public void PlayEndAnimation()
    {
        _animator.SetTrigger("IsEnd");
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
