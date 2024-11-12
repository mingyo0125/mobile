using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SummonItem : UIImage
{
    public override void Initialize()
    {
        base.Initialize();

        transform.localScale = Vector3.zero;

        //Sequence.Kill();

        Sequence
            .Prepend(transform.DOScale(1.3f, 0.3f).SetEase(Ease.OutBack))
            .Append(transform.DOScale(1f, 0.1f).SetEase(Ease.Linear))
            .Insert(0.05f,transform.DOShakePosition(0.05f, Vector2.one * 10, 10, 90));
    }
}
