using DG.Tweening;
using UnityEngine;

public class Twinkle : PoolableMono
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public override void Initialize()
    {
        base.Initialize();

        _spriteRenderer.color = Color.white;

        _spriteRenderer.DOFade(0f, 1f)
            .OnComplete(() => PoolManager.Instance.DestroyObject(this));
    }
}
