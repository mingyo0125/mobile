using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : UIComponent
{
    protected Button _button { get; private set; }

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
    }

    public override void UpdateUI()
    {

    }

}
