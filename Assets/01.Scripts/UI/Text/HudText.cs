using DG.Tweening;
using TMPro;
using UnityEngine;

public class HudText : PoolableMono
{
    [SerializeField]
    private float hudDuration = 0.5f;

    private Vector3 _originPos;

    private TextMeshPro _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();

        _originPos = transform.localPosition;
    }

    public void SpawnHudText(float damageValue)
    {
        _text.SetText(damageValue.ToString());

        float randomX = Random.value < 0.5f
        ? Random.Range(-0.5f, -0.3f)
        : Random.Range(0.5f, 0.3f);

        Vector2 targetPos = new Vector2(randomX, -0.25f);
        transform.DOLocalJump(targetPos, 1f, 1, hudDuration);

        transform.DOScale(Vector3.one * 0.5f, hudDuration).OnComplete(() =>
        {
            _text.color = new Color(0, 0, 0, 0);
            transform.DOKill();
            _text.color = Color.white;
            transform.SetParent(null);  
            PoolManager.Instance.DestroyObject(this);
        });
    }
}