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

    public void SpawnHudText(bool isCritical, float damageValue)
    {
        _text.SetText(damageValue.ToString());

        if (isCritical)
        {
            _text.color = Color.red;
            transform.localScale = Vector3.one * 1.5f;
        }

        float randomX = Random.value < 0.5f
        ? Random.Range(-0.5f, -0.3f)
        : Random.Range(0.5f, 0.3f);

        Vector2 targetPos = new Vector2(randomX, -0.25f);
        transform.DOLocalJump(targetPos, 1f, 1, hudDuration);

        transform.DOScale(Vector3.one * 0.5f, hudDuration).OnComplete(() =>
        {
            _text.color = Color.white;
            transform.localScale = Vector3.one;
            transform.SetParent(null);  
            PoolManager.Instance.DestroyObject(this);
        });
    }
}