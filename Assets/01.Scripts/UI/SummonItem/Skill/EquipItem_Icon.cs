using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem_Icon : SummonItem_Icon
{
    [SerializeField]
    private GameObject[] _usingPanels;

    private Color _originBGColor;

    private void Start()
    {
        _originBGColor = transform.Find("BG_Image/IconBG_Image").GetComponent<Image>().color;
        OnOffPanels(false);
    }

    public override void SetSummonItem(SummonItemInfo summonItem)
    {
        base.SetSummonItem(summonItem);

        OnOffPanels(true);
    }

    public void ReSetSummonItem()
    {
        _bgImage.color = _originBGColor;
        OnOffPanels(false);
    }

    private void OnOffPanels(bool isOn)
    {
        foreach (var panel in _usingPanels)
        {
            panel.SetActive(isOn);
        }
    }
}
