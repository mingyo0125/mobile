using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float MaxHP { get; private set; }

    [field: SerializeField]
    public float CheckAttackRange { get; private set;}
}
