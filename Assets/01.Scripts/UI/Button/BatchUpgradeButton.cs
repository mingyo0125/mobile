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
        foreach (SkillInfo skillInfo in SkillManager.Instance.Skill_Infos.Values)
        {
            // �׳� ���� ��ȭ�ص� �Žñ� ��
            CanUpgradeIcon_Image.SetActive(skillInfo.CanUpgrade);
        }
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
