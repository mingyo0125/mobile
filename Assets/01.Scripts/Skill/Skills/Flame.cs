using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : BaseSkill
{
    private bool isSpawned = false;
    public override void Initialize()
    {
        base.Initialize();

        isSpawned = true;
        transform.SetParent(GameManager.Instance.GetPlayerTrm());
    }
}
