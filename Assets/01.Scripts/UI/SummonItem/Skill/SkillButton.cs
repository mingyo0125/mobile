using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SkillButton : UI_Button
{
    private PlayerSkillHolder _skillHolder;

    [SerializeField]
    private Image _cooldownImage, _iconImage;

    private SkillButtonInfo _skillButtonInfo;

    private Coroutine _calculateSkillCooldownCoroutine;

    private void Start()
    {
        _skillHolder = GameManager.Instance.GetPlayer().SkillHolder;

        _skillButtonInfo = new SkillButtonInfo();
    }

    public void SubscribeSkill(BaseSkill skill)
    {
        Debug.LogFormat($"Subscribe {skill.SkillInfo.ItemName}");

        _skillButtonInfo.SetInfo(skill.SkillInfo);
        IsUsingButton = true;

        UpdateUI();
        //_button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => _calculateSkillCooldownCoroutine = StartCoroutine(CalculateSkillCooldownCorou()));
        _button.onClick.AddListener(() => _skillHolder.PlaySkill(skill.SkillInfo.ItemId));
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        _iconImage.sprite = _skillButtonInfo.Icon;
    }

    public void UnSubscribeSkill()
    {
        _iconImage.sprite = null;

        IsUsingButton = false;

        _skillButtonInfo.ResetInfo();
        _button.onClick.RemoveAllListeners();

        _cooldownImage.fillAmount = 0;
        _button.interactable = true;

        StopCoroutine(_calculateSkillCooldownCoroutine);
    }

    private IEnumerator CalculateSkillCooldownCorou()
    {
        float cooldownTime = _skillButtonInfo.CoolTime; // ��Ÿ�� ����
        float startTime = Time.time; // ���� �ð�
        float endTime = startTime + cooldownTime; // ���� �ð�

        _button.interactable = false;
        _cooldownImage.fillAmount = 1;

        while (Time.time < endTime)
        {
            float elapsedTime = Time.time - startTime;
            _cooldownImage.fillAmount = 1 - (elapsedTime / cooldownTime);


            yield return null;
        }

        _cooldownImage.fillAmount = 0;
        _button.interactable = true;
    }
}
