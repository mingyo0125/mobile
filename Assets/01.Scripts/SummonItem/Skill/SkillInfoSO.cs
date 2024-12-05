using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill")]
public class SkillInfoSO : ScriptableObject
{
    [field: SerializeField]
    public SkillInfo SkillInfo { get; private set; }

}
