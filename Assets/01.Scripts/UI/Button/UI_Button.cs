using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class UI_Button : UI_Component
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

    public void AddClickEvent(params UnityAction[] actions)
    {
        foreach (UnityAction action in actions) 
        {
            _button.onClick.AddListener(action);
        }
    }

}
