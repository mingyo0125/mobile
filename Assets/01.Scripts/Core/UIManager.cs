using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIManager : MonoSingleTon<UIManager>
{
    [SerializeField]
    private Canvas _canvas;

    private Stack<UIComponent> _uiComponentsStack = new Stack<UIComponent>();
    public UIComponent TopUI => _uiComponentsStack.Peek();

    private void Update()
    {
        //if(_uiComponentsStack.Count > 0 &&
        //   TopUI.IsActive)
        //{
        //    TopUI.UpdateUI();
        //}
    }

    public UIComponent GenerateUI(string name, Transform parent = null, UIGenerateType generateType = UIGenerateType.NONE)
    {
        if(parent == null) { parent = _canvas.transform; }

        UIComponent ui = PoolManager.Instance.CreateObject(name) as UIComponent;

        if (ui is null) { return null; }

        ui.GenerateUI(parent, generateType);

        if (generateType == UIGenerateType.STACKING) { _uiComponentsStack.Push(ui); }

        return ui;
    }

    public void RemoveTopUGUI()
    {
        if(_uiComponentsStack.Count > 0)
        {
            var top = _uiComponentsStack.Pop();
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
        List<UIComponent> generatedComponents = new List<UIComponent>();
        _canvas.GetComponentsInChildren(generatedComponents);

        foreach (var component in generatedComponents)
        {
            component.RemoveUI();
        }
    }


    public void SpawnHudText(Transform parentTrm, string value, Color textColor)
    {
        HudText _hudText = PoolManager.Instance.CreateObject("HudText") as HudText;
        _hudText.transform.SetParent(parentTrm);
        _hudText.SetPosition(parentTrm.position + new Vector3(0, 0.1f, 0));
        _hudText.SpawnHudText(value, textColor);
    }

    //Bezier 
    public void AttractPosition(Transform obj,
                                Vector2 startPos , Vector2 endPos,
                                float duration, float spreadPower,
                                params Action[] endActions)
    {
        StartCoroutine(AttractCorou(obj, startPos, endPos, duration, spreadPower, endActions));
    }

    private IEnumerator AttractCorou(Transform obj,
                                     Vector2 startPos, Vector2 endPos,
                                     float duration, float spreadPower,
                                     params Action[] endActions)
    {
        Debug.Log(spreadPower);
        Vector2 cetnerVec = startPos + Random.insideUnitCircle * spreadPower;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            Vector2 v1 = Vector2.Lerp(startPos, cetnerVec, t);
            Vector2 v2 = Vector2.Lerp(cetnerVec, endPos, t);

            obj.position = Vector2.Lerp(v1, v2, t);

            yield return null;
        }

        foreach (Action action in endActions)
        {
            action?.Invoke();
        }
    }
}
