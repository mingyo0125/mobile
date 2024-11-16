using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatUpgradeUIGenerater : ObjectFactory<UIComponent>, IScrollHandler
{
    private readonly string statUpgradeUIContatinerbaseName = "UpgradeStatContainer_v";

    public void OnScroll(PointerEventData eventData)
    {
        
    }

    private void Start()
    {
        int idx = 0;
        float height = 0;
        foreach(var item in GameManager.Instance.GetPlayerStat().Stats)
        {
            StatUpgradeUIContainer statUpgradeUIContainer =
                SpawnObject($"{statUpgradeUIContatinerbaseName}{idx % 2 + 1}",
                            transform.position) as StatUpgradeUIContainer; // v1이랑 v2만 있으니까

            float containerHeight = ((RectTransform)statUpgradeUIContainer.transform).rect.height;
            height += containerHeight;

            StatType statType = item.Key;
            statUpgradeUIContainer.SetStatType(statType);
            statUpgradeUIContainer.transform.SetParent(transform);

            //statUpgradeUIContainer.transform.localScale = Vector3.one;
            idx++;
        }

        ((RectTransform)transform).sizeDelta = new Vector2(100, height);
    }
}