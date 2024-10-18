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
                            transform.position) as StatUpgradeUIContainer; // v1이랑 v2만 있으니까

            StatType statType = item.Key;
            statUpgradeUIContainer.SetStatType(statType);
            statUpgradeUIContainer.transform.SetParent(transform);
            idx++;
        }
    }
}