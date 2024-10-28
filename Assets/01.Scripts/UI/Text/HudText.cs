using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudText : BaseHudText
{
    protected override void SpawnText(string value, Color textColor)
    {
        float yPos = transform.position.y - 0.5f;

        transform.DOMoveY(yPos, 0.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            PoolManager.Instance.DestroyObject(this);
        });
    }
}
