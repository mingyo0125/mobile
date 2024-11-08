using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : BaseSkill
{
    protected override void Awake()
    {
        base.Awake();

        _viusal.OnTakeDamageEvent += TakeDamage;
    }
}
