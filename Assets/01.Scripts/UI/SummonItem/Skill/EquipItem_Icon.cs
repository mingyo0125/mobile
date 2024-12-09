using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipItem_Icon : SummonItem_Icon
{
    [SerializeField]
    private GameObject[] _usingPanels;

    [SerializeField]
    private Image _replaceSummonItemButtonIcon, _replaceSummonItemButtonBG;

    [SerializeField]
    private ReplaceSkillButton _replaceSkillButton;

    private Color _originBGColor;

    private bool isEquipped = false;

    private void Start()
    {
        _originBGColor = transform.Find("BG_Image/IconBG_Image").GetComponent<Image>().color;
        OnOffPanels(false);

        Signalhub.OnSelectChnageSkillEvent += ChangeButtonEvent;
        Signalhub.OnReplaceSkillEvent += EndReplace;
    }

    public override void SetSummonItem(SummonItemInfo summonItem)
    {
        base.SetSummonItem(summonItem);

        _replaceSummonItemButtonBG.color = ItemInfo.GradeInfo.ColorByGrade;
        _replaceSummonItemButtonIcon.sprite = ItemInfo.Icon;
        isEquipped = true;

        OnOffPanels(true);
    }

    public void ReSetSummonItem()
    {
        _bgImage.color = _originBGColor;

        IsUsingButton = false;
        isEquipped = false;

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
        if (!isEquipped) { return; }

        _unEquipItemButton.gameObject.SetActive(true);

        _replaceSkillButton.gameObject.SetActive(false);
    }

    private void ChangeButtonEvent(SkillInfo skillInfo)
    {
        if(!isEquipped) { return; }

        _unEquipItemButton.gameObject.SetActive(false);
        _replaceSkillButton.gameObject.SetActive(true);
        _replaceSkillButton.SetSummonItemInfo(ItemInfo, skillInfo);
    }
}
