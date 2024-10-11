using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : EntityFactory<Item>
{
    private PlayerStat _playerStat;

    private void Start()
    {
        _playerStat = GameManager.Instance.GetPlayerTrm().GetComponent<Player>().EntityStat as PlayerStat;
    }

    public void SpawnItem(Vector2 spawnPos)
    {
        float itemDropProbabiltiy = 15f + Utils.CalculatePercent(15f, _playerStat.ItemDropRate); // 아이템 생성 확률 기본 15

        Debug.Log(itemDropProbabiltiy);

        bool canSpawnItem = Utils.CalculateProbability(itemDropProbabiltiy);

        if (!canSpawnItem) { return; }

        Item item = Utils.GetRandomElement(_spawnEntitys);
        SpawnObject(item.name, spawnPos);
    }
}
