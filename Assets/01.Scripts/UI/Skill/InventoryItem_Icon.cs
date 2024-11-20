using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem_Icon : SummonItem_Icon
{
    [Header("LockImage")]
    [SerializeField]
    private GameObject _lockPanel;

    [Header("LevelUp")]
    [SerializeField]
    private GameObject _targetAchievedImage;

    [Header("EquipOnOff")]
    [SerializeField]
    private GameObject _equippedIcon;

    [Header("ItemCount")]
    [SerializeField]
    private Image _itemCountFillAmountImage;
    [SerializeField]
    private TextMeshProUGUI _itemCountText;

    private bool isLocked = true;

    private void Start()
    {
        _equipButton.AddClickEvent(EquipItem);
        _unEquipItemButton.AddClickEvent(UnEquipItem);
    }

    protected override void Init()
    {
        base.Init();

        _icon.sprite = _summonItem.Icon;
        _summonItem.OnItemGetEvent += GetItem;
    }

    public void EquipItem()
    {
        _equippedIcon.SetActive(true);
        _unEquipItemButton.gameObject.SetActive(true);
        _equipButton.gameObject.SetActive(false);
    }

    private void UnEquipItem()
    {
        _equippedIcon.SetActive(false);
        _unEquipItemButton.gameObject.SetActive(false);
        _equipButton.gameObject.SetActive(true);
    }

    public void GetItem()
    {
        if(isLocked)
        {
            _lockPanel.SetActive(false);
            isLocked = false;
        }

        //int로만 하면 int의 나눗셈을 해서 소수점을 버림
        float fillAmount = Mathf.Clamp((float)_summonItem.ElementsCount / _summonItem.UpgradableCount,
                                       0,
                                       1);

        _itemCountFillAmountImage.fillAmount = fillAmount;
        _itemCountText.SetText($"{_summonItem.ElementsCount}/{_summonItem.UpgradableCount}");

        if(_summonItem.ElementsCount > _summonItem.UpgradableCount)
        {
            SetCanUpgrade();
        }
    }

    public void UnLockItem()
    {
        _lockPanel.SetActive(false);
    }

    private void SetCanUpgrade()
    {
        _targetAchievedImage.SetActive(true);
    }

    private void Upgrade()
    {
        _targetAchievedImage.SetActive(false);
    }
}
