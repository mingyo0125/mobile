using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImage : UIComponent
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
