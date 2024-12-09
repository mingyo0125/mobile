using TMPro;
using UnityEngine;

public class Equipment_InfoUI : ItemInfoUI<EquipmentInfo>
{
    [SerializeField]
    private TextMeshProUGUI _itemValueText;

    public override void Initialze()
    {
        base.Initialze();

        _itemValueText.SetText($"���ݷ� ���� {_itemInfo.ItemValue.ToString()}%");
    }
}
