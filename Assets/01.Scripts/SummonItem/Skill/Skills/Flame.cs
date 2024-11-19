using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : BaseSkill
{
    public override void Initialize()
    {
        base.Initialize();

        transform.SetParent(GameManager.Instance.GetPlayerTrm());
    }
}
