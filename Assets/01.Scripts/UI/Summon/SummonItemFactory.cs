using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SummonType
{
    Skill,

}


public class SummonItemFactory : ObjectFactory<SummonItem>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    public void SpawnSummonItem(SummonType summonType, int count)
    {
        for(int i = 0; i < count; i++)
        {

        }
    }

    //private List<PoolableMono> GetSummonItem(SummonType summonType)
    //{
        
    //}
}
