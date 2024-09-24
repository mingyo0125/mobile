using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity<PlayerStateType, Player>
{


    protected override void CreateStateMachine()
    {
        StateMachine = new PlayerStateMachine(this);
    }
}
