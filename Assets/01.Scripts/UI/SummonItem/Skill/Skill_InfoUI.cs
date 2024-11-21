using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill_InfoUI : UI_Image
{
    [SerializeField]
    private TextMeshProUGUI _descriptionText;

    [SerializeField]
    private TextMeshProUGUI _skillNameText;

    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private TextMeshProUGUI _countText;

    private SkillInfo _skillInfo;

    public void SetSkillInfo(SkillInfo skillInfo)
    {
        _skillInfo = skillInfo;
    }

    public void Initialze()
    {
        _descriptionText.SetText(_skillInfo.Description);
        _skillNameText.SetText(_skillInfo.ItemName);

        _levelText.SetText($"Lv.{_skillInfo.ItemLevel}");
        _countText.SetText($"{_skillInfo.ElementsCount / _skillInfo.UpgradableCount}");
    }

    public void UpdateLevelText()
    {
        _levelText.SetText($"Lv.{_skillInfo.ItemLevel}");
    }

    public void UpdateCountText()
    {
        _countText.SetText($"{_skillInfo.ElementsCount / _skillInfo.UpgradableCount}");
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        UpdateLevelText();
        UpdateCountText();
    }
}
