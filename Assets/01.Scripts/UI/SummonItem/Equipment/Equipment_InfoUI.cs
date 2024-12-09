using TMPro;
using UnityEngine;

public class Equipment_InfoUI : ItemInfoUI<EquipmentInfo>
{
    [SerializeField]
    private TextMeshProUGUI _itemValueText;

    public override void Initialze()
    {
        base.Initialze();

    }

    private void UpdateItemValueText()
    {
        _itemValueText.SetText($"공격력 증가 {_itemInfo.ItemValue.ToString()}%");
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        UpdateItemValueText();
    }
}
