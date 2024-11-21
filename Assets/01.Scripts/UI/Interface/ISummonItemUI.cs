using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummonItemUI
{
    public SummonItemInfo _summonItem { get; set; }
    public void SetSummonItem(SummonItemInfo summonItem);
}
