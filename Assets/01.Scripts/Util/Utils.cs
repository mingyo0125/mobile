using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static float CalculatePercent(float value, float percentvalue)
    {
        return value * (percentvalue * 0.01f);
    }

    public static bool CalculateProbability(float probability)
    {
        float randomValue = Random.Range(0f, 100f);
        // 랜덤값이 확률보다 작으면 성공
        bool success = randomValue < probability;
        return success;
    }

    public static T GetRandomElement<T>(T[] array)
    {
        int randomIdx = Random.Range(0, array.Length);
        return array[randomIdx];
    }

    public static T GetRandomElement<T>(List<T> list)
    {
        int randomIdx = Random.Range(0, list.Count);
        return list[randomIdx];
    }

    public static Vector2 GetRandomSpawnPos(Vector3 minBound, Vector3 maxBound)
    {
        float randomX = Random.Range(minBound.x, maxBound.x);
        float randomY = Random.Range(minBound.y, maxBound.y);

        return new Vector2(randomX, randomY);
    }
}
