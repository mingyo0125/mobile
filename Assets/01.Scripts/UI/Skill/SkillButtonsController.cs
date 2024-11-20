using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillButtonsController : MonoBehaviour
{
    private List<SkillButton> _skillButtons = new List<SkillButton>();

    private Dictionary<BaseSkill, SkillButton> _usingSkillButtons = new Dictionary<BaseSkill, SkillButton>();

    private void Awake()
    {
        _skillButtons = GetComponentsInChildren<SkillButton>().ToList();
    }

    public void SubscribeSkill(BaseSkill skill)
    {
        // ���߿� ���� �ؼ� ���� later
        SkillButton skillButton = GetEmptyButton();
        if (skillButton != null) // ��ų ĭ�� �� �� ��������
        {
            skillButton.SubscribeSkill(skill.SkillInfo.ItemId);

            _usingSkillButtons.Add(skill, skillButton);
            return;
        }

        // ��ųĭ�� �� �������� �Ұ� ����
    }

    public void UnSubscribeSkill(BaseSkill skill)
    {
        if (!_usingSkillButtons.TryGetValue(skill, out SkillButton button)) { return; }

        button.UnSubscribeSkill();

        _usingSkillButtons.Remove(skill);

        return;
    }

    private SkillButton GetEmptyButton()
    {
        foreach(SkillButton button in _skillButtons)
        {
            if(!button.IsUsingButton)
            {
                return button;
            }
        }

        return null;
    }
}
