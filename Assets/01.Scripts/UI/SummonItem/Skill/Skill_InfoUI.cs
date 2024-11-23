using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill_InfoUI : ItemInfoUI<SkillInfo>
{
    #region SkillInfo

    [SerializeField]
    private TextMeshProUGUI _descriptionText;

    #endregion

    public override void Initialze()
    {
        base.Initialze();

        _descriptionText.SetText(_itemInfo.Description);
    }

}
