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
    private Image _itemCountFillAmount;
    [SerializeField]
    private TextMeshProUGUI _itemCountText;

    private void Start()
    {
        _equipButton.AddClickEvent(EquipItem);
        _summonItem.OnItemEquipEvent += EquipItem;
        _summonItem.OnItemGetEvent += GetItem;

        //_unEquipButton.AddClickEvent(UnEquipItem);
    }

    protected override void Init()
    {
        base.Init();

        _icon.sprite = _summonItem.Icon;
    }

    public void EquipItem()
    {
        _equippedIcon.SetActive(true);
        //_unEquipButton.gameObject.SetActive(true);
    }

    private void UnEquipItem()
    {
        _equippedIcon.SetActive(false);
        //_unEquipButton.gameObject.SetActive(false);

    }

    public void GetItem()
    {
        Debug.Log("°³¾¾¹ß");
        _lockPanel.SetActive(false);
    }

    public void UnLockItem()
    {
        _lockPanel.SetActive(false);
    }
}
