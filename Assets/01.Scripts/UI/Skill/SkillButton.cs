using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SkillButton : UIButton
{
    private PlayerSkillHolder _skillHolder;

    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        _skillHolder = GameManager.Instance.GetPlayer().SkillHolder;

        AddSkill("Fireball");
    }

    public void AddSkill(string skillID)
    {
        Debug.Log(_skillHolder);
        bool isContainsSkill = _skillHolder.Skills.ContainsKey(skillID);
        Debug.Log(isContainsSkill);
        if (!isContainsSkill) { return; }

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => _skillHolder.PlaySkill(skillID));
    }
}
