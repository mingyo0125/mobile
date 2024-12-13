using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGenerateButton : UI_Button
{
    [SerializeField]
    private string generateUIName;

    [SerializeField]
    private UIGenerateType _uiGenerateType;

    [SerializeField]
    private UIGenerateSortType _uiGenerateSortType;

    [SerializeField]
    private UIGenerateTweenType _uiGenerateTweenType;

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        UIManager.Instance.CreateUI(generateUIName, Vector2.zero, null, _uiGenerateType, _uiGenerateSortType, _uiGenerateTweenType);
    }
}
