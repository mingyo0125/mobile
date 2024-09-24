using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : EntityStateMachine<PlayerStateType, Player>
{
    public PlayerStateMachine(Player player) : base(player)
    {
    }
}
