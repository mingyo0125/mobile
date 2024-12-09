using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipItem_Icon : SummonItem_Icon
{
    [SerializeField]
    private GameObject[] _usingPanels;

    [SerializeField]
    private Image _replaceSkillButtonIcon, _replaceSkillButtonBG;

    [SerializeField]
    private ReplaceSkillButton _replaceSkillButton;

    private Color _originBGColor;

    private void Start()
    {
        _originBGColor = transform.Find("BG_Image/IconBG_Image").GetComponent<Image>().color;
        OnOffPanels(false);
    }

    public void SetEquipItem_Icon(ItemType itemType)
    {
        if (itemType == ItemType.Skill)
        {
            Signalhub.OnSelectChnageSkillEvent += ChangeButtonEvent;
            Signalhub.OnReplaceSkillEvent += EndReplace;
        }

    }

    public override void SetSummonItem(SummonItemInfo summonItem)
    {
        base.SetSummonItem(summonItem);

        _replaceSkillButtonBG.color = ItemInfo.GradeInfo.ColorByGrade;
        _replaceSkillButtonIcon.sprite = ItemInfo.Icon;

        OnOffPanels(true);
    }

    public void ReSetSummonItem()
    {
        _bgImage.color = _originBGColor;

        IsUsingButton = false;

        OnOffPanels(false);
    }

    private void OnOffPanels(bool isOn)
    {
        foreach (var panel in _usingPanels)
        {
            panel.SetActive(isOn);
        }
    }

    private void EndReplace()
    {
        _unEquipItemButton.gameObject.SetActive(true);

        _replaceSkillButton.gameObject.SetActive(false);
    }

    private void ChangeButtonEvent(SkillInfo skillInfo)
    {
        _unEquipItemButton.gameObject.SetActive(false);
        _replaceSkillButton.gameObject.SetActive(true);
        _replaceSkillButton.SetSummonItemInfo(ItemInfo, skillInfo);
    }
}
