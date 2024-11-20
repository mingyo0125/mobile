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
        // 나중에 지정 해서 저장 later
        SkillButton skillButton = GetEmptyButton();
        if (skillButton != null) // 스킬 칸이 다 안 차있으면
        {
            skillButton.SubscribeSkill(skill.SkillInfo.ItemId);

            _usingSkillButtons.Add(skill, skillButton);
            return;
        }

        // 스킬칸이 다 차있으면 할거 무언가
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
