using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JewelText : CurrencyText
{
    protected override CurrencyType GetCurrencyType()
    {
        return CurrencyType.Jewel;
    }
}
