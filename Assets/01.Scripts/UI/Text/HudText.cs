using DG.Tweening;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HudText : TextMeshPro
{
    [SerializeField]
    private float hudDuration = 0.5f;

    private Vector3 _originPos;

    protected override void Awake()
    {
        base.Awake();

        _originPos = transform.localPosition;
    }

    public void SpawnHudText(float damageValue)
    {
        transform.DOKill();

        color = Color.white;
        transform.localScale = Vector3.one;

        SetText(damageValue.ToString());

        float randomX = Random.value < 0.5f
        ? Random.Range(-0.5f, -0.3f)
        : Random.Range(0.5f, 0.3f);

        Vector2 targetPos = new Vector2(randomX, -0.25f);
        transform.DOLocalJump(targetPos, 1f, 1, hudDuration);

        transform.DOScale(Vector3.one * 0.5f, hudDuration).OnComplete(() =>
        {
            color = new Color(0, 0, 0, 0);
        });
    }
}