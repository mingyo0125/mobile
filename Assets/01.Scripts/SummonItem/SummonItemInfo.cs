using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SummonItemInfo
{
    [field: SerializeField]
    public string ItemName { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [field: SerializeField]
    public float SummonProbability { get; private set; }


    // ���߿� ����ȭ ����� later
    [field: SerializeField]
    public int ElementsCount { get; private set; }

    public void AddElementsCount()
    {
        ElementsCount++;
    }
}
