using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Button : UI_Component
{
    protected Button _button { get; private set; }
    public Button Button => _button;

    private List<UnityAction> _actions = new List<UnityAction>();

    public bool IsUsingButton { get; protected set; } = false;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(ButtonEvent);
    }

    protected virtual void ButtonEvent()
    {
        var actionsCopy = new List<UnityAction>(_actions);
        foreach (var action in actionsCopy)
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

    public void RemoveClickEvent(params UnityAction[] actions)
    {
        foreach (UnityAction action in actions)
        {
            _actions.Remove(action);
        }
    }

    public void AddClickEvent(List<UnityAction> actions)
    {
        foreach (UnityAction action in actions)
        {
            _actions.Add(action);
        }
    }

    public List<UnityAction> RemoveClickEventAll()
    {
        List<UnityAction> actions = new List<UnityAction>(_actions);
        _actions.Clear();
        return actions;
    }

    public void SetInteractableButton(bool interactable)
    {
        _button.interactable = interactable;
    }
}
