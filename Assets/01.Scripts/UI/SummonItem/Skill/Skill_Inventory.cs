using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Inventory : SummonItem_Inventory<SkillInfo>
{
    private void Start()
    {
        Signalhub.OnSelectChnageSkillEvent += GenerateEquippingSkillUI;
    }

}
