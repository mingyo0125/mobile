using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatUpgradeUIGenerater : ObjectFactory<UI_Component>
{
    private readonly string statUpgradeUIContatinerbaseName = "UpgradeStatContainer_v";

    private void Start()
    {
        int idx = 0;
        float height = 0;
        foreach(var item in GameManager.Instance.GetPlayerStat().Stats)
        {
            if (!item.Value.StatUIInfo.isCanUpgrade) { continue; } // ���׷��̵� �����Ѱ͸� �������� ���׷��̵� �ǵ���

            StatUpgradeUIContainer statUpgradeUIContainer =
                SpawnObject($"{statUpgradeUIContatinerbaseName}{idx % 2 + 1}",
                            transform.position) as StatUpgradeUIContainer; // v1�̶� v2�� �����ϱ�

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