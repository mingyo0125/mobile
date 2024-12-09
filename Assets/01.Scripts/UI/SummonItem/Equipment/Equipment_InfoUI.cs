using TMPro;
using UnityEngine;

public class Equipment_InfoUI : ItemInfoUI<EquipmentInfo>
{
    [SerializeField]
    private TextMeshProUGUI _itemValueText;

    public override void Initialze()
    {
        base.Initialze();

        _itemValueText.SetText($"공격력 증가 {_itemInfo.ItemValue.ToString()}%");
    }
}
