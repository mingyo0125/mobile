using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingSkillUI : UI_Component
{
    [SerializeField]
    private GameObject _allSkillsUI;

    public override void UpdateUI()
    {
        _allSkillsUI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void SetInfo()
    {

    }

}
