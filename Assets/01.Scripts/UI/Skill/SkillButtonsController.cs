using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillButtonsController : MonoBehaviour
{
    private List<SkillButton> _skillButtons = new List<SkillButton>();

    private Queue<SkillButton> _notUsedButtons;

    private Dictionary<BaseSkill, SkillButton> _usingSkillButtons = new Dictionary<BaseSkill, SkillButton>();

    private void Awake()
    {
        _skillButtons = GetComponentsInChildren<SkillButton>().ToList();

        _notUsedButtons = new Queue<SkillButton>(_skillButtons);
    }

    public void SubscribeSkill(BaseSkill skill)
    {
        // ���߿� ���� �ؼ� ���� later
        if(_notUsedButtons.Count > 0) // ��ų ĭ�� �� �� ��������
        {
            SkillButton button = _notUsedButtons.Dequeue();
            button.SubscribeSkill(skill.SkillInfo.ItemId);

            _usingSkillButtons.Add(skill, button);
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
}
