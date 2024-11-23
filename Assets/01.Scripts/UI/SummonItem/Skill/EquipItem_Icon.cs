using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem_Icon : SummonItem_Icon
{
    [SerializeField]
    private GameObject[] _usingPanels;

    private void Start()
    {
        OnOffPanels(false);
    }

    public override void SetSummonItem(SummonItemInfo summonItem)
    {
        base.SetSummonItem(summonItem);

        OnOffPanels(true);
    }

    private void OnOffPanels(bool isOn)
    {
        foreach (var panel in _usingPanels)
        {
            panel.SetActive(isOn);
        }
    }
}
