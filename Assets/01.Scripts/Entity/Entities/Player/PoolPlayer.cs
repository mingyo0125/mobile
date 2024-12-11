using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPlayer : PoolableMono
{
    [SerializeField]
    Player _player;

    public override void Initialize()
    {
        base.Initialize();

        _player.Initialize();
    }
}
