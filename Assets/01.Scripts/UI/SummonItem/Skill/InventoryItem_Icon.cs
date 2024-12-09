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

    [SerializeField]
    private EquipItemButton _equipButton;

    private int siblingIndex = 999;

    public override void SetSummonItem(SummonItemInfo summonItem)
    {
        base.SetSummonItem(summonItem);

        _equipButton.SetSummonItem(ItemInfo);
        UnLockItem();
    }

    protected override void Init()
    {
        base.Init();

        ItemInfo.OnItemUnEquipEvent += UnEquipItem;
        ItemInfo.OnItemEquipEvent += EquipItem;
        ItemInfo.OnItemLevelUpEvent += UpdateItemCountUI;
        ItemInfo.OnItemGetEvent += UpdateItemCountUI;
    }

    public void UpdateItemCountUI()
    {
        UnLockItem();
        SetCanUpgrade(ItemInfo.CanUpgrade);

        //int로만 하면 int의 나눗셈을 해서 소수점을 버림
        float fillAmount = Mathf.Clamp((float)ItemInfo.ElementsCount / ItemInfo.UpgradableCount,
                                       0,
                                       1);

        _itemCountFillAmountImage.fillAmount = fillAmount;
        _itemCountText.SetText($"{ItemInfo.ElementsCount}/{ItemInfo.UpgradableCount}");
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
        if (!ItemInfo.IsLock)
        {
            _lockPanel.SetActive(false);
        }
    }

    private void SetCanUpgrade(bool canUpgrade)
    {
        _targetAchievedImage.SetActive(canUpgrade);
    }

    public void SetSiblingIndex(int siblingIndex)
    {
        this.siblingIndex = siblingIndex;
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        UpdateItemCountUI();
    }

    public void ChangeParent(Transform parent)
    {
        transform.SetParent(parent);
        transform.SetSiblingIndex(siblingIndex);
    }
}
