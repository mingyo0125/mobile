using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillButtonsController : MonoBehaviour
{
    private List<SkillButton> _skillButtons = new List<SkillButton>();

    private Dictionary<BaseSkill, SkillButton> _usingSkillButtons = new Dictionary<BaseSkill, SkillButton>();

    private EquippedSkillsController _equippedSkillsController;
    private EquippedSkillsController EquippedSkillsController
    {
        get
        {
            if(_equippedSkillsController == null)
            {
                _equippedSkillsController = FindAnyObjectByType<EquippedSkillsController>();
            }
            return _equippedSkillsController;
        }
    }

    private void Awake()
    {
        _skillButtons = new List<SkillButton>(GetComponentsInChildren<SkillButton>());
    }

    public bool SubscribeSkill(BaseSkill skill)
    {
        // ���߿� ���� �ؼ� ���� later
        SkillButton skillButton = GetEmptyButton();
        if (skillButton != null) // ��ų ĭ�� �� �� ��������
        {
            skillButton.SubscribeSkill(skill);

            _usingSkillButtons.Add(skill, skillButton);

            EquippedSkillsController.EquippedSkill(skill.SkillInfo);
            return true;
        }

        Signalhub.OnSelectChnageSkillEvent?.Invoke(skill.SkillInfo);
        return false;
        // ��ųĭ�� �� �������� �Ұ� ����
    }

    public void UnSubscribeSkill(BaseSkill skill)
    {
        if (!_usingSkillButtons.TryGetValue(skill, out SkillButton button)) { return; }

        button.UnSubscribeSkill();

        _usingSkillButtons.Remove(skill);
        EquippedSkillsController.UnEquippedSkill(skill.SkillInfo);

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