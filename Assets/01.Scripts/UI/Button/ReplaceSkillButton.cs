using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSkillButton : UI_Button
{
    private SummonItemInfo _curSummonItemInfo;
    private SummonItemInfo _changeSummonItemInfo;

    private void Start()
    {
        AddClickEvent(ReplaceSkill);
    }

    public void SetSummonItemInfo(SummonItemInfo curSummonItemInfo, SummonItemInfo changeSummonItemInfo)
    {
        _curSummonItemInfo = curSummonItemInfo;
        _changeSummonItemInfo = changeSummonItemInfo;
    }

    private void ReplaceSkill()
    {
        Debug.Log("dkd");

        InventoryManager.Instance.UnEquipItem(_curSummonItemInfo.ItemType, _curSummonItemInfo.ItemId);

        InventoryManager.Instance.EquipItem(_changeSummonItemInfo);

        Signalhub.OnReplaceSkillEvent?.Invoke();

        gameObject.SetActive(false);
    }
}
