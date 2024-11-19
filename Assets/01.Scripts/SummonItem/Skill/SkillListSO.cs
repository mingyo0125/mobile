using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SkillList")]
public class SkillListSO : ScriptableObject
{
    [field: SerializeField]
    public List<BaseSkill> SkillLists { get; private set; }
}
