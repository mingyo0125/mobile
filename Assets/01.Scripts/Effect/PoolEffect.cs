using DG.Tweening;
using UnityEngine;

public class PoolEffect : PoolableMono
{
    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Initialize()
    {
        _spriteRenderer.color = Color.white;
    }

    public void OnAnimationEndEvent()
    {
        _spriteRenderer.DOFade(0f, 0.2f)
            .OnComplete(() => PoolManager.Instance.DestroyObject(this));
    }

}
