using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillButtonsController : MonoBehaviour
{
    private List<SkillButton> _skillButtons = new List<SkillButton>();

    private Queue<SkillButton> _notUsedButtons;

    private Dictionary<SkillButton, BaseSkill> _usingSkillButtons = new Dictionary<SkillButton, BaseSkill>();

    private void Awake()
    {
        _skillButtons = GetComponentsInChildren<SkillButton>().ToList();

        _notUsedButtons = new Queue<SkillButton>(_skillButtons);
    }

    public void SubscribeSkill(BaseSkill skill)
    {
        // 나중에 지정 해서 저장 later
        if(_notUsedButtons.Count > 0) // 스킬 칸이 다 안 차있으면
        {
            SkillButton button = _notUsedButtons.Dequeue();
            button.SubscribeSkill(skill.SkillInfo.ItemId);

            _usingSkillButtons.Add(button, skill);
            return;
        }

        // 스킬칸이 다 차있으면 할거 무언가
    }

    public void UnSubscribeSkill()
    {
        if (_notUsedButtons.Count <= 0) // 스킬 칸에 지워져 있지 않으면
        {
            return;
        }

        // 나중에 지정 해서 지움 later

        SkillButton button = _notUsedButtons.Dequeue();
        button.UnSubscribeSkill();

        _usingSkillButtons.Remove(button);
        return;
    }
}
