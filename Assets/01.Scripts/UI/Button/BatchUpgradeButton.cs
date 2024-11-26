using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatchUpgradeButton : UI_Button
{
    [SerializeField]
    private GameObject CanUpgradeIcon_Image;

    private void Start()
    {
        foreach (SkillInfo skillInfo in SkillManager.Instance.Skill_Infos.Values)
        {
            skillInfo.OnItemGetEvent += OnCanUpgradeIcon_Image;
            skillInfo.OnItemLevelUpEvent += OnCanUpgradeIcon_Image;
        }
    }

    private void OnCanUpgradeIcon_Image()
    {
        bool canUpgrade = false;
        foreach (SkillInfo skillInfo in SkillManager.Instance.Skill_Infos.Values)
        {
            // 그냥 각자 강화해도 거시기 됨
            if(skillInfo.CanUpgrade)
            {
                canUpgrade = true;
                break;
            }
        }

        CanUpgradeIcon_Image.SetActive(canUpgrade);
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        foreach(SkillInfo skillInfo in SkillManager.Instance.Skill_Infos.Values)
        {
            while(skillInfo.CanUpgrade)
            {
                skillInfo.ItemLevelUp();
            }
        }
    }

}
