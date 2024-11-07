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

    public override void Execute(Player user, Vector2 pos)
    {
        PlayEffect(pos);
    }
}
