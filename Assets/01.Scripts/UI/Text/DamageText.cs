using DG.Tweening;
using UnityEngine;

public class DamageText : BaseHudText
{
    protected override void SpawnText(string value, Color textColor)
    {
        if (textColor == Color.red) // 크리티컬이면
        {
            transform.localScale = Vector3.one * 1.5f;
        }

        float randomX = Random.value < 0.5f
        ? Random.Range(-0.5f, -0.3f)
        : Random.Range(0.5f, 0.3f);

        Vector2 targetPos = (Vector2)transform.position + new Vector2(randomX, -0.25f);
        transform.DOLocalJump(targetPos, 1f, 1, hudDuration);

        transform.DOScale(Vector3.one * 0.5f, hudDuration).OnComplete(() =>
        {
            _text.color = Color.white;
            transform.localScale = Vector3.one;
            PoolManager.Instance.DestroyObject(this);
        });
    }
}
