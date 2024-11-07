using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : BaseSkill
{
    public override void Execute(Player user, Vector2 pos)
    {
        PlayEffect(pos);
    }
}
