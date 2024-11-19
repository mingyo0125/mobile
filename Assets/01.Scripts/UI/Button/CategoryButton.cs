using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryButton : UI_Button
{
    [SerializeField]
    private string categoryName;

    [SerializeField]
    private Transform _SpawnUIparentTrm;

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        UIManager.Instance.RemoveTopUGUI();
        UIManager.Instance.GenerateUI(categoryName, _SpawnUIparentTrm, UIGenerateType.STACKING);
    }

    private void Start()
    {
        transform.localScale = Vector3.one;
    }


}
