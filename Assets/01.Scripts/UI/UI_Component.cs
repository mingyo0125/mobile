using DG.Tweening;
using UnityEngine;

public abstract class UI_Component : PoolableMono, IGUI
{
    public Transform Parent { get; private set; }
    public UIGenerateType GenerateType { get; private set; }

    public bool IsActive { get; private set; }

    private Sequence _sequence;

    protected Sequence Sequence
    {
        get
        {
            _sequence = DOTween.Sequence();

            return _sequence;
        }
    }

    public void GenerateUI(Transform parent, UIGenerateType generateType)
    {
        if (generateType == UIGenerateType.CLEAR_PANEL)
        {
            UIManager.Instance.ClearPanel();
        }

        transform.SetParent(parent);

        transform.localPosition = Vector2.zero;
        ((RectTransform)transform).anchoredPosition = Vector2.zero;
        ((RectTransform)transform).sizeDelta = Vector2.zero;
        transform.localScale = Vector2.one;

        //if (generateType == UIGenerateType.SETPOS)
        //{
        //    ((RectTransform)transform).offsetMin = Vector2.zero;
        //    ((RectTransform)transform).offsetMax = Vector2.zero;
        //}

        IsActive = true;
        Parent = parent;
        GenerateType = generateType;
    }

    public virtual void RemoveUI()
    {
        IsActive = false;
        PoolManager.Instance.DestroyObject(this);
    }

    private void OnDisable()
    {
        if (_sequence != null && _sequence.IsActive())
        {
            transform.localScale = Vector2.one;
            _sequence.Kill();
            _sequence = null;
        }
    }

    public abstract void UpdateUI();
}
