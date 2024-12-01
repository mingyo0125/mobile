using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Image : UI_Component
{
    [field: SerializeField]
    public Image Icon { get; private set; }

    public override void UpdateUI()
    {

    }

    public virtual void UpdateImage(Sprite sprite)
    {
        Icon.sprite = sprite;
    }
}
