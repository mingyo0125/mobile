using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonsController : MonoBehaviour
{
    private List<SkillButton> _skillButtons = new List<SkillButton>();

    private Dictionary<BaseSkill, SkillButton> _usingSkillButtons = new Dictionary<BaseSkill, SkillButton>();

    private EquippedSkillsController _equippedSkillsController;
    private EquippedSkillsController EquippedSkillsController
    {
        get
        {
            if(_equippedSkillsController == null)
            {
                _equippedSkillsController = FindAnyObjectByType<EquippedSkillsController>();
            }
            return _equippedSkillsController;
        }
    }

    private bool isAutoPlay;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);

    private void Awake()
    {
        _skillButtons = new List<SkillButton>(GetComponentsInChildren<SkillButton>());
    }

    public bool SubscribeSkill(BaseSkill skill)
    {
        // 나중에 지정 해서 저장 later
        SkillButton skillButton = GetEmptyButton();
        if (skillButton != null) // 스킬 칸이 다 안 차있으면
        {
            skillButton.SubscribeSkill(skill);

            _usingSkillButtons.Add(skill, skillButton);

            EquippedSkillsController.EquippedSkill(skill.SkillInfo);
            return true;
        }

        Signalhub.OnSelectChnageSkillEvent?.Invoke(skill.SkillInfo);
        return false;
        // 스킬칸이 다 차있으면 할거 무언가
    }

    public void UnSubscribeSkill(BaseSkill skill)
    {
        if (!_usingSkillButtons.TryGetValue(skill, out SkillButton button)) { return; }

        button.UnSubscribeSkill();

        _usingSkillButtons.Remove(skill);
        EquippedSkillsController.UnEquippedSkill(skill.SkillInfo);

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
    
    public void SetAutoPlay(bool autoPlay)
    {
        isAutoPlay = autoPlay;

        StartCoroutine(AutoPlaySkillCorou());
    }

    private IEnumerator AutoPlaySkillCorou()
    {
        while (isAutoPlay && GameManager.Instance.GetPlayer().IsAttack)
        {
            foreach (SkillButton button in _skillButtons)
            {
                if (button.Button.interactable)
                {
                    button.Button.onClick?.Invoke();
                }

                yield return _waitForSeconds;
            }

            yield return null;
        }
    }
}
