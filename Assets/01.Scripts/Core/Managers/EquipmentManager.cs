using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentManager : SummonItemManager<EquipmentInfo>
{
    [SerializeField]
    private EquipmentInfoListSO _equipmentInfoListSO;

    public Dictionary<string, EquipmentInfo> EquipmentInfoList { get; private set; } = new Dictionary<string, EquipmentInfo>();

    private Equipment_Inventory _equipment_Inventory;

    private EquipmentInfo _curEquipmentInfo;

    protected override void Awake()
    {
        foreach (EquipmentInfoSO equipmentInfoSO in _equipmentInfoListSO.EquipmentInfoList)
        {
            EquipmentInfo equipmentInfo = new EquipmentInfo(equipmentInfoSO.EquipmentInfo);
            EquipmentInfoList.Add(equipmentInfo.ItemId, equipmentInfo);
        }

        base.Awake();
    }

    private void Start()
    {
        _equipment_Inventory = FindAnyObjectByType<Equipment_Inventory>();

    }

    protected override List<EquipmentInfo> GetSummonItems()
    {
        return EquipmentInfoList.Values.ToList();
    }

    public override void UnEquipSummonItem(string itemId)
    {
        if (!EquipmentInfoList.TryGetValue(itemId, out EquipmentInfo equipmentInfo)) { return; }
        
        GameManager.Instance.GetPlayer().EntityStatController.DecreaseStat(StatType.Damage, equipmentInfo.ItemValue);

        base.UnEquipSummonItem(itemId);

        _curEquipmentInfo = null;

        _equipment_Inventory.UnEquipItem();
    }

    public override bool EquipSummonItem(string itemId)
    {
        if (!EquipmentInfoList.TryGetValue(itemId, out EquipmentInfo equipmentInfo)) { return false; }

        _equipment_Inventory.EquipItem(equipmentInfo);

        // 무기만 할꺼니까 데미지로 함
        GameManager.Instance.GetPlayer().EntityStatController.IncreaseStat(StatType.Damage, equipmentInfo.ItemValue);

        _curEquipmentInfo = equipmentInfo;

        return base.EquipSummonItem(itemId);
    }

    public EquipmentInfo GetCurEquipmentInfo()
    {
        if (_curEquipmentInfo != null)
        {
            return _curEquipmentInfo;
        }

        Debug.LogWarning("CurEquipment is null");
        return null;
    }
}
