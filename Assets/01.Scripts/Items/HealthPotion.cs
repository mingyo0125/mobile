using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    protected override void GetItem(Player player)
    {
        player.SetHp(10, Color.green);
    }
}
