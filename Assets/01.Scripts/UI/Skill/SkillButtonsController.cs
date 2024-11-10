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
<<<<<<< HEAD
        if(_notUsedButtons.Count <= 0) // 스킬 칸이 다 안 차있으면
=======
        if(_notUsedButtons.Count > 0) // 스킬 칸이 다 안 차있으면
>>>>>>> 1661aa9498a9e29315c3803a459a7d5c9688ae55
        {
            SkillButton button = _notUsedButtons.Dequeue();
            button.SubscribeSkill(skill.SkillInfo.SkillName);

            _usingSkillButtons.Add(button, skill);
            return;
        }

        // 스킬칸이 다 차있으면 할거 무언가
    }
}
