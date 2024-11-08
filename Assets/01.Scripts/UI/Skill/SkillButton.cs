using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SkillButton : UIButton
{
    [SerializeField]
    private string testSkillInput;

    private PlayerSkillHolder _skillHolder;

    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        _skillHolder = GameManager.Instance.GetPlayer().SkillHolder;

        AddSkill(testSkillInput);
    }

    public void AddSkill(string skillID)
    {
        bool isContainsSkill = _skillHolder.Skills.ContainsKey(skillID);
        if (!isContainsSkill) { return; }

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => _skillHolder.PlaySkill(skillID));
    }
}
