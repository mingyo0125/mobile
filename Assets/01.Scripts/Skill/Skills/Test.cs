using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : BaseSkill
{
    public override void Execute(Player user)
    {
        Debug.Log(_skillInfo.Description);
    }
}
