using DG.Tweening;
using System;
using UnityEngine;

public class PoolEffect : MonoBehaviour
{
    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    public event Action OnDestoryEvent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize()
    {
        _spriteRenderer.color = Color.white;
    }

    public void AnimationEndEvent()
    {
        _spriteRenderer.DOFade(0f, 0.2f)
            .OnComplete(() => OnDestoryEvent?.Invoke());
    }

}
