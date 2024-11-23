using UnityEngine;

public class EquippingSkillUI : UI_Component
{
    [SerializeField]
    private GameObject _allSkillsUI;

    [SerializeField]
    private Transform _equipSkillButtonTrm;

    private const string inventoryItemIcon = "Inventory_ItemIcon";

    private InventoryItem_Icon _equippingItem_Icon;
    private Transform _prevequippingItemParentTrm;

    private void Start()
    {
        Signalhub.OnReplaceSkillEvent += CloseEquippingSkillUI;
    }

    public override void UpdateUI()
    {
        _allSkillsUI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void SetSkillInfo(InventoryItem_Icon inventoryItem_Icon)
    {
        _equippingItem_Icon = inventoryItem_Icon;
        _prevequippingItemParentTrm = inventoryItem_Icon.transform.parent;
        inventoryItem_Icon.transform.SetParent(_equipSkillButtonTrm);
    }

    public void CloseEquippingSkillUI()
    {
        _equippingItem_Icon.transform.SetParent(_prevequippingItemParentTrm);
        _equippingItem_Icon = null;

        _allSkillsUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
