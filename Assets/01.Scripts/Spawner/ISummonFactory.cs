using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummonFactory 
{
    public SummonItemFactory<T> GetFactory<T>() where T : SummonItemInfo;
}
