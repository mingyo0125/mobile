using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIManager : MonoSingleTon<UIManager>
{
    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private Transform _deaultUIParentTrm;

    private Stack<UI_Component> _uiComponentsStack = new Stack<UI_Component>();
    public UI_Component TopUI => _uiComponentsStack.Peek();

    private void Update()
    {
        //if(_uiComponentsStack.Count > 0 &&
        //   TopUI.IsActive)
        //{
        //    TopUI.UpdateUI();
        //}
    }

    public UI_Component GenerateUI(string name, Transform parent = null, UIGenerateType generateType = UIGenerateType.NONE,
                                                                         UIGenerateSortType sortType = UIGenerateSortType.STACKING)
    {
        if(parent == null) { parent = _deaultUIParentTrm; }
        if (sortType == UIGenerateSortType.TOP) { parent = _canvas.transform; }

        UI_Component ui = PoolManager.Instance.CreateObject(name) as UI_Component;

        if (ui is null) { return null; }

        ui.GenerateUI(parent, generateType);

        if (generateType == UIGenerateType.STACKING) { _uiComponentsStack.Push(ui); }

        return ui;
    }

    public void RemoveTopUGUI()
    {
        if(_uiComponentsStack.Count > 0)
        {
            UI_Component top = _uiComponentsStack.Pop();
            top.RemoveUI();
        }
    }

    public void ReturnUI()
    {
        if (_uiComponentsStack.Count <= 0)
        {
            Debug.LogWarning("There is not exist current UI");
            return;
        }

        var curComponent = _uiComponentsStack.Pop();

        if (_uiComponentsStack.Count <= 0)
        {
            Debug.LogWarning("There is not exist prev UI");
            return;
        }

        var prevComponent = _uiComponentsStack.Pop();

        curComponent.RemoveUI();
        GenerateUI(prevComponent.name, prevComponent.Parent, prevComponent.GenerateType);
    }

    public void ClearPanel()
    {
        List<UI_Component> generatedComponents = new List<UI_Component>();
        _canvas.GetComponentsInChildren(generatedComponents);

        foreach (var component in generatedComponents)
        {
            component.RemoveUI();
        }
    }


    public void SpawnHudText(Vector2 pos, string value, Color textColor)
    {
        HudText _hudText = PoolManager.Instance.CreateObject("HudText") as HudText;
        //_hudText.transform.SetParent(parentTrm);

        _hudText.SetPosition(pos);
        _hudText.SpawnHudText(value, textColor);
    }

    public void SpawnDamageText(Vector2 pos, string value, Color textColor)
    {
        DamageText _hudText = PoolManager.Instance.CreateObject("DamageText") as DamageText;
        //_hudText.transform.SetParent(parentTrm);

        _hudText.SetPosition(pos);
        _hudText.SpawnHudText(value, textColor);
    }
}
