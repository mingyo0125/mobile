using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfoUI<T> : UI_Image where T : SummonItemInfo
{
    #region ItemInfo

    [field: SerializeField]
    protected TextMeshProUGUI _skillNameText { get; private set; }

    [field: SerializeField]
    protected TextMeshProUGUI _levelText { get; private set; }

    [field: SerializeField]
    protected TextMeshProUGUI _countText { get; private set; }

    protected T _itemInfo { get; private set; }

    #endregion

    public void SetSkillInfo(T itemInfo)
    {
        _itemInfo = itemInfo;
        Initialze();
    }

    public virtual void Initialze()
    {
        _icon.sprite = _itemInfo.Icon;
        _skillNameText.SetText(_itemInfo.ItemName);

        UpdateUI();
    }

    public void UpdateLevelText()
    {
        _levelText.SetText($"Lv.{_itemInfo.ItemLevel}");
    }

    public void UpdateCountText()
    {
        _countText.SetText($"{_itemInfo.ElementsCount / _itemInfo.UpgradableCount}");
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        UpdateLevelText();
        UpdateCountText();
    }


}
