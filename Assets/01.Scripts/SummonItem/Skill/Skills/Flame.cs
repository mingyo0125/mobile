using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : BaseSkill
{
    protected override void Awake()
    {
        _viusal.OnTakeDamageEvent += TakeDamage;
    }

    public override void Initialize()
    {
        base.Initialize();

        transform.SetParent(GameManager.Instance.GetPlayerTrm());
    }
}
