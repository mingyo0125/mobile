using DG.Tweening;
using UnityEngine;

public abstract class UIComponent : PoolableMono, IGUI
{
    public Transform Parent { get; private set; }
    public UIGenerateType GenerateType { get; private set; }

    public bool IsActive { get; private set; }

    private Sequence _sequence;

    protected Sequence Sequence
    {
        get
        {
            if (_sequence == null)
            {
                _sequence = DOTween.Sequence();
                return _sequence;
            }
            
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

    private void OnDisable()
    {
        if (_sequence != null && _sequence.IsActive())
        {
            _sequence.Kill();
        }
    }

    public abstract void UpdateUI();
}
