using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemFactory : ObjectFactory<SummonItem>
{
    private List<SummonItem> _prevSpawnItems = new List<SummonItem>();

    [SerializeField]
    private float spawnDelayTime = 0.05f;

    private const string SummonItem = "SummonItem_Image";

    private const int xDistance = 150, yDistance = -150;

    public virtual void SpawnSummonItem(Transform spawnParentTrm, int count)
    {
        _prevSpawnItems.ForEach(item => PoolManager.Instance.DestroyObject(item));
        _prevSpawnItems.Clear();

        StartCoroutine(SpawnSummonItemCorou(spawnParentTrm, count));
    }

    private IEnumerator SpawnSummonItemCorou(Transform spawnParentTrm, int count)
    {
        int xCount = 0, yCount = 0;

        List<SummonItemInfo> summonedItem = GetSummonItems(GetCanSummonItems(), count);

        foreach (SummonItemInfo item in summonedItem)
        {
            SummonItem summonItem = PoolManager.Instance.CreateObject(SummonItem) as SummonItem;
            summonItem.transform.SetParent(spawnParentTrm);
            summonItem.UpdateImage(item.Icon);
            item.GetItem();

            _prevSpawnItems.Add(summonItem);

            spawnParentTrm.DOShakePosition(spawnDelayTime, Vector2.one * 10, 10, 90);

            SetSummonItemPos(summonItem, xCount, yCount);

            xCount++;

            if (xCount == 5)
            {
                xCount = 0;
                yCount++;
            }

            yield return new WaitForSeconds(spawnDelayTime);
        }
    }

    private List<SummonItemInfo> GetSummonItems(List<SummonItemInfo> cansummonItems, int count)
    {
        List<SummonItemInfo> results = new List<SummonItemInfo>();

        float totalProbability = 0f;
        foreach (var equipment in cansummonItems)
        {
            totalProbability += equipment.SummonProbability;
        }

        for (int i = 0; i < count; i++)
        {
            float randomPoint = Random.value * totalProbability;

            foreach (SummonItemInfo item in cansummonItems)
            {
                if (randomPoint < item.SummonProbability)
                {
                    results.Add(item);
                    break;
                }
                randomPoint -= item.SummonProbability;
            }
        }

        return results;
    }

    private void SetSummonItemPos(SummonItem summonItem, int xCount, int yCount)
    {
        RectTransform rectTransform = (RectTransform)summonItem.transform;

        rectTransform.anchoredPosition = new Vector2(50, -50);

        rectTransform.anchoredPosition += new Vector2(xDistance * xCount, yDistance * yCount);
    }

    public abstract List<SummonItemInfo> GetCanSummonItems();
}
