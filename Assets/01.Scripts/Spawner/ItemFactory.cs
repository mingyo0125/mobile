using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : EntityFactory<Item>
{
    public void SpawnItem(Vector2 spawnPos)
    {
        bool canSpawnItem = Utils.CalculateProbability(100f); // ³ªÁß¿¡ SO

        Item item = Utils.GetRandomElement(_spawnEntitys);
        SpawnObject(item.name, spawnPos);
    }
}
