using UnityEngine;

public class StatUpgradeUIGenerater : ObjectFactory<UIComponent>
{
    private readonly string statUpgradeUIContatinerbaseName = "UpgradeStatContainer_v";

    private void Start()
    {
        int idx = 0;
        foreach(var item in GameManager.Instance.GetPlayerStat().Stats)
        {
            StatUpgradeUIContainer statUpgradeUIContainer =
                SpawnObject($"{statUpgradeUIContatinerbaseName}{idx % 2 + 1}",
                            transform.position) as StatUpgradeUIContainer; // v1�̶� v2�� �����ϱ�

            StatType statType = item.Key;
            statUpgradeUIContainer.SetStatType(statType);
            statUpgradeUIContainer.transform.SetParent(transform);
            idx++;
        }
    }
}