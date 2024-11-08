using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SkillButton : UIButton
{
    [SerializeField]
    private string testSkillInput;

    private PlayerSkillHolder _skillHolder;

    private Image _cooldownImage;

    private SkillButtonInfo _skillButtonInfo;

    private void Start()
    {
        _skillHolder = GameManager.Instance.GetPlayer().SkillHolder;
    }

    public void SubscribeSkill(string skillID)
    {
        bool isContainsSkill = _skillHolder.CanUseSkills.TryGetValue(skillID, out BaseSkill skill);
        if (!isContainsSkill) { return; }

        if(_skillButtonInfo == null)
        {
            _skillButtonInfo = new SkillButtonInfo(skill.SkillInfo.SkillName,
                                                   skill.SkillInfo.Description,
                                                   skill.SkillInfo.Cooldown);
        }

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(AddPermanentEvent);
        _button.onClick.AddListener(() => _skillHolder.PlaySkill(skillID));
    }

    public void UnSubscribeSkill()
    {
        _skillButtonInfo = null;
    }

    private void AddPermanentEvent()
    {
        //_button.onClick.AddListener(() => StartCoroutine(CalculateSkillCooldownCorou()));
    }

    private IEnumerator CalculateSkillCooldownCorou()
    {
        float goalTime = Time.time + _skillButtonInfo.CoolTime;

        _button.interactable = false;

        _cooldownImage.fillAmount = 1;

        while (Time.time < goalTime)
        {
            _cooldownImage.fillAmount = 1 - Time.time / goalTime;

            yield return null;
        }

        _cooldownImage.fillAmount = 0;
        _button.interactable = true;
    }
}
