using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private Image _itemCountFillAmountImage;

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

    [SerializeField]
    private SummonItemUpgradeButton _summonItemUpgradeButton;

    protected T _itemInfo { get; private set; }

    private ISummonItemUI[] _summonItemUIs;

    #endregion

    private void Awake()
    {
        _summonItemUIs = GetComponentsInChildren<ISummonItemUI>();
    }

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

        foreach(ISummonItemUI summonItemUI in _summonItemUIs)
        {
            summonItemUI.SetSummonItem(_itemInfo);
        }

        _lockPanel.SetActive(_itemInfo.IsLock);
        Debug.Log($"{_itemInfo.ItemName} : {_itemInfo.IsLock}");

        _targetAchievedImage.SetActive(_itemInfo.CanUpgrade);

        _itemInfo.OnItemLevelUpEvent += UpdateUI;

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
        Debug.Log("UpdateCountText");
        if(_itemInfo.CanUpgrade)
        {
            _targetAchievedImage.SetActive(true);
        }
        else
        {
            _targetAchievedImage.SetActive(false);
        }

        // int로만 하면 int의 나눗셈을 해서 소수점을 버림
        float fillAmount = Mathf.Clamp((float)_itemInfo.ElementsCount / _itemInfo.UpgradableCount,
                                       0,
                                       1);

        _itemCountFillAmountImage.fillAmount = fillAmount;
        _countText.SetText($"{_itemInfo.ElementsCount}/{_itemInfo.UpgradableCount}");
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        _unEquipButton.gameObject.SetActive(false);

        if (_itemInfo.isEquipped)
        {
            OnUnEquipButton();
        }

        UpdateLevelText();
        UpdateCountText();
    }


}
