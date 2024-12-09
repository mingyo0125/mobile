using UnityEngine;

public class EquippingSkillUI : EquippingSummonItemUI
{
    private void Start()
    {
        Signalhub.OnReplaceSkillEvent += CloseEquippingSkillUI;

    }
}
