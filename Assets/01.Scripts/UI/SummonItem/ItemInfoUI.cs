using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI<T> : UI_Image where T : SummonItemInfo
{
    #region ItemInfo

    [field: SerializeField]
    protected TextMeshProUGUI _skillNameText { get; private set; }

    [field: SerializeField]
    protected TextMeshProUGUI _levelText { get; private set; }

    [field: SerializeField]
    protected TextMeshProUGUI _countText { get; private set; }

    [SerializeField]
    private Image _bgImage;
    [SerializeField]
    private GameObject _lockPanel;

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
        _bgImage.color = _itemInfo.GradeInfo.ColorByGrade;

        _lockPanel.SetActive(!_itemInfo.IsLock);

        UpdateUI();
    }

    public void UpdateLevelText()
    {
        _levelText.SetText($"Lv.{_itemInfo.ItemLevel}");
    }

    public void UpdateCountText()
    {
        _countText.SetText($"{_itemInfo.ElementsCount}/{_itemInfo.UpgradableCount}");
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        UpdateLevelText();
        UpdateCountText();
    }


}
