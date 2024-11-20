using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryButton : UI_Button
{
    [SerializeField]
    private string categoryName;

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        UIManager.Instance.RemoveTopUGUI();
        UIManager.Instance.GenerateUI(categoryName, null, UIGenerateType.STACKING);
    }

    private void Start()
    {
        transform.localScale = Vector3.one;
    }


}
