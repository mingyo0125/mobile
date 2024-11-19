using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem_Icon : SummonItem_Icon
{
    [SerializeField]
    private GameObject _equipItemButton;

    [SerializeField]
    private GameObject _targetAchievedImage;

    [SerializeField]
    private Image _equippedIcon;

    [SerializeField]
    private Image _itemCountFillAmount;

    [SerializeField]
    private TextMeshProUGUI _itemCountText;

    //[SerializeField]
    //private UnEquipButton _unEquipButton;

    
    public void EquipItem()
    {
        //_equippedIcon
    }
}
