using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
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

    [SerializeField]
    private EquipItemButton _equipButton;

    private void Start()
    {
        _equipButton.AddClickEvent(EquipItem);

        _unEquipItemButton.AddClickEvent(UnEquipItem);
    }

    public override void SetSummonItem(SummonItemInfo summonItem)
    {
        base.SetSummonItem(summonItem);

        _equipButton.SetSummonItem(ItemInfo);
    }

    protected override void Init()
    {
        base.Init();

        ItemInfo.OnItemGetEvent += GetItem;
    }

    public void GetItem()
    {
        if (ItemInfo.IsLock)
        {
            _lockPanel.SetActive(false);
        }

        //int로만 하면 int의 나눗셈을 해서 소수점을 버림
        float fillAmount = Mathf.Clamp((float)ItemInfo.ElementsCount / ItemInfo.UpgradableCount,
                                       0,
                                       1);

        _itemCountFillAmountImage.fillAmount = fillAmount;
        _itemCountText.SetText($"{ItemInfo.ElementsCount}/{ItemInfo.UpgradableCount}");

        if (ItemInfo.ElementsCount >= ItemInfo.UpgradableCount)
        {
            SetCanUpgrade();
        }
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
