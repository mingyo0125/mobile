using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHpBar : Image
{
    private float maxHp;

    public void UpdateMaxHp(float maxHp)
    {
        this.maxHp = maxHp;
    }

    public void SetHpbarValue(float curHp)
    {
        fillAmount = curHp / maxHp;
        Debug.Log(fillAmount);
    }
}