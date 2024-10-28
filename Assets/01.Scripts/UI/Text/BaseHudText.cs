using DG.Tweening;
using TMPro;
using UnityEngine;

public abstract class BaseHudText : PoolableMono
{
    [SerializeField]
    protected float hudDuration = 0.5f;

    protected TextMeshPro _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    private void SetHudText(string value, Color textColor)
    {
        transform.SetParent(null);
        _text.SetText(value.ToString());
        _text.color = textColor;
    }

    public void SpawnHudText(string value, Color textColor)
    {
        SetHudText(value, textColor);
        SpawnText(value, textColor);
    }

    protected abstract void SpawnText(string value, Color textColor);
}