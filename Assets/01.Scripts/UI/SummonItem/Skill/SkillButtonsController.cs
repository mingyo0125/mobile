using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonsController : MonoBehaviour
{
    private List<SkillButton> _skillButtons = new List<SkillButton>();

    private Dictionary<BaseSkill, SkillButton> _usingSkillButtons = new Dictionary<BaseSkill, SkillButton>();

    private EquippedSummonItemController _equippedSkillsController;
    private EquippedSummonItemController EquippedSkillsController
    {
        get
        {
            if(_equippedSkillsController == null)
            {
                _equippedSkillsController = FindAnyObjectByType<EquippedSummonItemController>();
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
        // ���߿� ���� �ؼ� ���� later
        SkillButton skillButton = GetEmptyButton();
        if (skillButton != null) // ��ų ĭ�� �� �� ��������
        {
            skillButton.SubscribeSkill(skill);

            _usingSkillButtons.Add(skill, skillButton);

            EquippedSkillsController.EquippedSummonItem(skill.SkillInfo);
            return true;
        }

        Signalhub.OnSelectChnageSkillEvent?.Invoke(skill.SkillInfo);
        return false;
        // ��ųĭ�� �� �������� �Ұ� ����
    }

    public void UnSubscribeSkill(BaseSkill skill)
    {
        if (!_usingSkillButtons.TryGetValue(skill, out SkillButton button)) { return; }

        button.UnSubscribeSkill();

        _usingSkillButtons.Remove(skill);
        EquippedSkillsController.UnEquippedSummonItem(skill.SkillInfo);

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

        if (isAutoPlay)
        {
            StartCoroutine(AutoPlaySkillCorou());
        }
    }

    private IEnumerator AutoPlaySkillCorou()
    {
        while (isAutoPlay)
        {
            foreach (SkillButton button in _skillButtons)
            {
                if (button.Button.interactable && GameManager.Instance.GetPlayer().CanAttack)
                {
                    button.Button.onClick?.Invoke();
                }

                yield return _waitForSeconds;
            }

            yield return null;
        }
    }
}
