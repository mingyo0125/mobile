using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAutoPlayButtonController : UI_Button
{
    private bool isAutoPlaying;

    private SkillButtonsController _skillButtonsController;

    [SerializeField]
    private Button autoPlayUI, unAutoPlayUI;

    protected override void Awake()
    {
        _skillButtonsController = FindAnyObjectByType<SkillButtonsController>();

        autoPlayUI.onClick.AddListener(ButtonEvent);
        unAutoPlayUI.onClick.AddListener(ButtonEvent);
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        isAutoPlaying = !isAutoPlaying;

        Debug.Log(isAutoPlaying);

        autoPlayUI.gameObject.SetActive(isAutoPlaying);
        unAutoPlayUI.gameObject.SetActive(!isAutoPlaying);

        _skillButtonsController.SetAutoPlay(isAutoPlaying);
    }
}
