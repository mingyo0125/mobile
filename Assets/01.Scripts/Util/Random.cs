using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Random
{
    public static bool CalculateProbability(float probability)
    {
        float randomValue = UnityEngine.Random.Range(0f, 100f);
        // �������� Ȯ������ ������ ����
        bool success = randomValue < probability;
        return success;
    }
}
