using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : ObjectFactory<Item>
{
    public void SpawnItem(Vector2 spawnPos)
    {
        float itemDropProbabiltiy = GameManager.Instance.GetPlayerStat().ItemDropRate.Value;

        bool canSpawnItem = Utils.CalculateProbability(itemDropProbabiltiy);

        if (!canSpawnItem) { return; }

        Item item = Utils.GetRandomElement(_spawnEntitys);
        SpawnObject(item.name, spawnPos);
    }

}
