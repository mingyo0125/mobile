using System.Collections.Generic;
using UnityEngine;

public static class Calculator
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
}
