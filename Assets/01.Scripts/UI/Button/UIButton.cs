using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIButton : UIComponent
{
    protected Button _button { get; private set; }

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(ButtonEvent);
    }

    protected virtual void ButtonEvent()
    {

    }

    public override void UpdateUI()
    {

    }

}
