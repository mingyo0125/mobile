using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummonItem
{
    public float GetSummonProbability();
    public Sprite GetSummonIcon();
    public void GetItem();
    public int GetElementsCount();
    public void AddElementsCount();
}
