using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemFactory<T> : ObjectFactory<SummonItem>, ISummonFactory where T : SummonItemInfo
{
    private List<SummonItem> _prevSpawnItems = new List<SummonItem>();

    private const float spawnDelayTime = 0.05f;

    private const string SummonItem = "SummonItem_Image";

    private const int xDistance = 150, yDistance = -150;

    private Coroutine _setSummonItemPosCoroutine;
    private WaitForSeconds _setSummonItemPosWaitSeconds = new WaitForSeconds(spawnDelayTime);

    public virtual void SpawnSummonItem(Transform spawnParentTrm, int count)
    {
        if(_setSummonItemPosCoroutine != null)
        {
            StopCoroutine(_setSummonItemPosCoroutine);
            _setSummonItemPosCoroutine = null;
        }

        _prevSpawnItems.ForEach(item => PoolManager.Instance.DestroyObject(item)); // 전에 소환된거 지움
        _prevSpawnItems.Clear();                                                   // 전에 소환된거 지움

        List<T> summonedItem = GetSummonItems(GetCanSummonItems(), count);
        List<SummonItem> summonItemUIs = new List<SummonItem>();

        foreach (T item in summonedItem)
        {
            SummonItem summonItem = PoolManager.Instance.CreateObject(SummonItem) as SummonItem;
            summonItemUIs.Add(summonItem);

            summonItem.SetBGImage(item.GradeInfo.ColorByGrade);
            summonItem.UpdateImage(item.Icon);

            item.GetItem();

            _prevSpawnItems.Add(summonItem);
        }

        _setSummonItemPosCoroutine = StartCoroutine(SetSummonItemPosCorou(summonItemUIs, spawnParentTrm));
    }

    private List<T> GetSummonItems(List<T> cansummonItems, int count)
    {
        List<T> results = new List<T>();

        // 1. 각 아이템의 누적 확률 계산
        float totalProbability = 0f;
        List<float> cumulativeProbabilities = new List<float>();
        foreach (var item in cansummonItems)
        {
            totalProbability += item.GetSummonProbability();
            cumulativeProbabilities.Add(totalProbability); // 누적 확률 추가
        }

        // 2. count만큼 아이템 선택
        for (int i = 0; i < count; i++)
        {
            float randomPoint = Random.value * totalProbability;

            // 3. 누적 확률 범위를 기반으로 아이템 선택
            for (int j = 0; j < cumulativeProbabilities.Count; j++)
            {
                if (randomPoint <= cumulativeProbabilities[j])
                {
                    results.Add(cansummonItems[j]);
                    break;
                }
            }
        }

        return results;
    }


    private IEnumerator SetSummonItemPosCorou(List<SummonItem> summonItemUIs, Transform spawnParentTrm)
    {
        int xCount = 0, yCount = 0;

        foreach (SummonItem summonItem in summonItemUIs)
        {
            spawnParentTrm.DOShakePosition(spawnDelayTime, Vector2.one * 10, 10, 90);

            summonItem.ScaleTween();

            summonItem.transform.SetParent(spawnParentTrm);
            RectTransform rectTransform = (RectTransform)summonItem.transform;
            rectTransform.anchoredPosition = new Vector2(50, -50);
            rectTransform.anchoredPosition += new Vector2(xDistance * xCount, yDistance * yCount);

            xCount++;

            if (xCount == 5)
            {
                xCount = 0;
                yCount++;
            }

            yield return _setSummonItemPosWaitSeconds;
        }
    }

    public abstract List<T> GetCanSummonItems();

    public SummonItemFactory<G> GetFactory<G>() where G : SummonItemInfo
    {
        return this as SummonItemFactory<G>;
    }
}
