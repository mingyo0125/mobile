using DG.Tweening;
using UnityEngine;

public abstract class UIComponent : PoolableMono, IGUI
{
    public Transform Parent { get; private set; }
    public UIGenerateType GenerateType { get; private set; }

    public bool IsActive { get; private set; }

    protected Sequence _sequence { get; private set; }

    private void Awake()
    {
        _sequence = DOTween.Sequence();
    }

    public void GenerateUI(Transform parent, UIGenerateType generateType)
    {
        if (generateType == UIGenerateType.CLEAR_PANEL)
        {
            UIManager.Instance.ClearPanel();
        }

        transform.SetParent(parent);

        if (generateType == UIGenerateType.SETPOS)
        {
            ((RectTransform)transform).offsetMin = Vector2.zero;
            ((RectTransform)transform).offsetMax = Vector2.zero;
        }

        IsActive = true;
        Parent = parent;
        GenerateType = generateType;
    }

    public virtual void RemoveUI()
    {
        IsActive = false;
        PoolManager.Instance.DestroyObject(this);
    }

    public abstract void UpdateUI();
}
