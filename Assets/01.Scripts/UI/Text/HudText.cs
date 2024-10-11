using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HudText : PoolableMono
{
    [SerializeField]
    private float hudDuration = 0.5f;

    private TextMeshPro _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    public void SpawnHudText(string value, Color textColor)
    {
        transform.SetParent(null);

        _text.SetText(value.ToString());

        _text.color = textColor;

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