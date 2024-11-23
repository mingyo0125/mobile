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
    private EquipItemButton _equipButton;

    [SerializeField]
    private UnEquipItemButton _unEquipButton;

    [SerializeField]
    private GameObject _targetAchievedImage;

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
        _equipButton.SetSummonItem(_itemInfo);
        _unEquipButton.SetSummonItem(_itemInfo);

        _lockPanel.SetActive(_itemInfo.IsLock);
        Debug.Log($"{_itemInfo.ItemName} : {_itemInfo.IsLock}");

        _targetAchievedImage.SetActive(_itemInfo.ElementsCount >= _itemInfo.UpgradableCount);
        UpdateUI();
    }

    public void OnUnEquipButton()
    {
        _unEquipButton.gameObject.SetActive(true);
    }

    public void UpdateLevelText()
    {
        _levelText.SetText($"Lv.{_itemInfo.ItemLevel}");
    }

    public void UpdateCountText()
    {
        if(_itemInfo.ElementsCount >= _itemInfo.UpgradableCount)
        {
            _targetAchievedImage.SetActive(true);
        }

        _countText.SetText($"{_itemInfo.ElementsCount}/{_itemInfo.UpgradableCount}");
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        _unEquipButton.gameObject.SetActive(false);

        UpdateLevelText();
        UpdateCountText();
    }


}
