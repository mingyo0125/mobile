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
        Debug.Log($"Subscribe{skill}");

        if(_notUsedButtons.Count > 0) // ��ų ĭ�� �� �� ��������
        {
            Debug.Log($"Subscribe{skill}");
            SkillButton button = _notUsedButtons.Dequeue();
            button.SubscribeSkill(skill.SkillInfo.ItemId);

            _usingSkillButtons.Add(button, skill);
            return;
        }

        // ��ųĭ�� �� �������� �Ұ� ����
    }
}
