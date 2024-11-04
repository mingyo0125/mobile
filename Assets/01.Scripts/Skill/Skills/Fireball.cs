using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BaseSkill
{
    public override void Execute(Player user, Vector2 pos)
    { 
        Debug.Log(_skillInfo.Description);
        PlayEffect(pos);
    }
}
