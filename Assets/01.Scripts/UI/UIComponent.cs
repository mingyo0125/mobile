using UnityEngine;

public abstract class UIComponent : PoolableMono, IGUI
{
    public Transform Parent { get; private set; }
    public UIGenerateType GenerateType { get; private set; }

    public bool IsActive { get; private set; }

    public void GenerateUI(Transform parent, UIGenerateType generateType)
    {
        if (generateType == UIGenerateType.CLEAR_PANEL)
        {
            //UIManager.Instance.ClearPanel();
        }

        transform.SetParent(parent);

        if (generateType == UIGenerateType.SETPOS)
        {
            ((RectTransform)transform).offsetMin = Vector2.zero;
            ((RectTransform)transform).offsetMax = Vector2.zero;
        }

        IsActive = false;
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
