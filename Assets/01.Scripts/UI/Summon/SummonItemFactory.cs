using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemFactory<T> : ObjectFactory<SummonItem> where T : ISummonItem
{
    public abstract List<T> GetCanSummonItems();

    public virtual void SpawnSummonItem(int count)
    {
        List<T> summonedItem = GetSummonItems(GetCanSummonItems(), 10);

        foreach(T item in summonedItem)
        {
            Debug.Log(item.GetSummonProbability());
        }
    }

    private List<T> GetSummonItems(List<T> cansummonItems, int count)
    {
        List<T> results = new List<T>();

        float totalProbability = 0f;
        foreach (var equipment in cansummonItems)
        {
            totalProbability += equipment.GetSummonProbability();
        }

        for (int i = 0; i < count; i++)
        {
            float randomPoint = Random.value * totalProbability;

            foreach (T item in cansummonItems)
            {
                if (randomPoint < item.GetSummonProbability())
                {
                    results.Add(item);
                    break;
                }
                randomPoint -= item.GetSummonProbability();
            }
        }

        return results;
    }
}
