using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class UIManager : MonoSingleTon<UIManager>
{
    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private Transform _deaultUIParentTrm;

    private Stack<UI_Component> _uiComponentsStack = new Stack<UI_Component>();
    public UI_Component TopUI => _uiComponentsStack.Peek();

    public UI_Component CreateUI(string name, Vector2 pos,
                                 Transform parent = null, 
                                 UIGenerateType generateType = UIGenerateType.NONE,
                                 UIGenerateSortType sortType = UIGenerateSortType.STACKING,
                                 UIGenerateTweenType tweenType = UIGenerateTweenType.None,
                                 float duration = 0.1f)
    {
        if(parent == null) { parent = _deaultUIParentTrm; }
        if (sortType == UIGenerateSortType.TOP) { parent = _canvas.transform; }

        UI_Component ui = PoolManager.Instance.CreateObject(name) as UI_Component;

        if (ui is null) { return null; }

        ui.GenerateUI(parent, generateType);

        if (generateType == UIGenerateType.STACKING) { _uiComponentsStack.Push(ui); }

        if(tweenType != UIGenerateTweenType.None)
        {
            Vector2 startPos = pos + new Vector2(0, (int)tweenType * 2000f);

            ((RectTransform)ui.transform).anchoredPosition = startPos;

            ((RectTransform)ui.transform).DOAnchorPos(pos, duration).SetEase(Ease.OutQuad);
        }

        return ui;
    }

    public void RemoveTopUGUI(UIGenerateTweenType tweenType = UIGenerateTweenType.None, float duration = 0.1f)
    {
        if(_uiComponentsStack.Count > 0)
        {
            UI_Component top = _uiComponentsStack.Pop();

            Debug.Log(top.name);

            if (tweenType != UIGenerateTweenType.None)
            {
                Vector2 endPos = ((RectTransform)top.transform).anchoredPosition + new Vector2(0, (int)tweenType * 2000f);

                ((RectTransform)top.transform).DOAnchorPos(endPos, duration)
                    .SetEase(Ease.OutQuad)
                    .OnComplete(() => top.RemoveUI());

                return;
            }

            top.RemoveUI();
        }
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
