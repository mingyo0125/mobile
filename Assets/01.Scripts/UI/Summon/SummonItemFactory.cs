using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemFactory<T> : ObjectFactory<SummonItem> where T : ISummonItem
{
    [SerializeField]
    private Transform _spawnParentTrm;

    private const string SummonItem = "SummonItem_Image";

    public virtual void SpawnSummonItem(int count)
    {
        List<T> summonedItem = GetSummonItems(GetCanSummonItems(), count);

        foreach(T item in summonedItem)
        {
            SummonItem summonItem = PoolManager.Instance.CreateObject(SummonItem) as SummonItem;
            summonItem.transform.SetParent(_spawnParentTrm);
            summonItem.UpdateImage(item.GetSummonIcon());
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

    public abstract List<T> GetCanSummonItems();
}
