using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Image : UI_Component
{
    [field: SerializeField]
    protected Image _icon { get; private set; }

    public override void UpdateUI()
    {

    }

    public virtual void UpdateImage(Sprite sprite)
    {
        _icon.sprite = sprite;
    }
}
