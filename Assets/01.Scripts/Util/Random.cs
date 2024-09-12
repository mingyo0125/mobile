using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Random
{
    public static bool CalculateProbability(float probability)
    {
        float randomValue = UnityEngine.Random.Range(0f, 100f);
        // 랜덤값이 확률보다 작으면 성공
        bool success = randomValue < probability;
        return success;
    }
}
