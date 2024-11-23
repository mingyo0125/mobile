using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummonItemUI
{
    public SummonItemInfo ItemInfo { get; set; }
    public void SetSummonItem(SummonItemInfo summonItem);
}
