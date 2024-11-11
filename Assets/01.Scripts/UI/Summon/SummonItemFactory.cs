using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonItemFactory<T> : ObjectFactory<SummonItem> where T : ISummonItem
{
    public virtual void SpawnSummonItem(, int count)
    {
        for(int i = 0; i < count; i++)
        {
            T item = 
        }
    }

    private List<T> GetSummonItems(T[] cansummonItems, int count)
    {
        List<T> results = new List<T>();

        for (int i = 0; i < count; i++)
        {
            float totalProbability = 0f;
            foreach (var equipment in cansummonItems)
            {
                totalProbability += equipment.GetSummonProbability();
            }

            float randomPoint = Random.value * totalProbability;

            foreach (var equipment in cansummonItems)
            {
                if (randomPoint < equipment.GetSummonProbability())
                {
                    results.Add(equipment);
                    break;
                }
                randomPoint -= equipment.GetSummonProbability();
            }
        }

        return results;
    }
}
