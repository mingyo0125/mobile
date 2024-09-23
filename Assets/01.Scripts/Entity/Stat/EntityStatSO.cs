using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat")]
public class EntityStatSO : ScriptableObject
{
    [field: SerializeField]
    public Stat EntityStat { get; private set; }
}
