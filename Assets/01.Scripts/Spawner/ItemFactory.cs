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
        float itemDropProbabiltiy = _playerStat.ItemDropRate;

        bool canSpawnItem = Utils.CalculateProbability(itemDropProbabiltiy);

        if (!canSpawnItem) { return; }

        Item item = Utils.GetRandomElement(_spawnEntitys);
        SpawnObject(item.name, spawnPos);
    }
}
