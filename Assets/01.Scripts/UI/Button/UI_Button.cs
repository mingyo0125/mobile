using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class UI_Button : UI_Component
{
    protected Button _button { get; private set; }

    private List<UnityAction> _actions = new List<UnityAction>();

    public bool IsUsingButton { get; protected set; } = false;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(ButtonEvent);
    }

    protected virtual void ButtonEvent()
    {
        foreach(var action in _actions)
        {
            action?.Invoke();
        }
    }

    public override void UpdateUI()
    {

    }

    public void AddClickEvent(params UnityAction[] actions)
    {
        foreach (UnityAction action in actions) 
        {
            _actions.Add(action);
        }
    }

}
