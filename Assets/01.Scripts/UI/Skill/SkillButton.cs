using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SkillButton : UI_Button
{
    [SerializeField]
    private string testSkillInput;

    private PlayerSkillHolder _skillHolder;

    [SerializeField]
    private Image _cooldownImage, _iconImage;

    private SkillButtonInfo _skillButtonInfo;

    private void Start()
    {
        _skillHolder = GameManager.Instance.GetPlayer().SkillHolder;

        _skillButtonInfo = new SkillButtonInfo();
    }

    public void SubscribeSkill(string skillID)
    {
        bool isContainsSkill =  _skillHolder.CanUseSkills.TryGetValue(skillID, out BaseSkill skill);
        if (!isContainsSkill) { return; }

        _skillButtonInfo.SetInfo(skill.SkillInfo);

        UpdateUI();
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(AddPermanentEvent);
        _button.onClick.AddListener(() => _skillHolder.PlaySkill(skillID));
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        _iconImage.sprite = _skillButtonInfo.Icon;
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
