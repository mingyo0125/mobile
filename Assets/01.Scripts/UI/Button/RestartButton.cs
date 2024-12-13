using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : UI_Button
{
    protected override void ButtonEvent()
    {
        ReStartGame();
    }

    private void ReStartGame()
    {
        GameManager.Instance.GetPlayer().gameObject.SetActive(true);
        GameManager.Instance.GetPlayer().Initialize();

        WaveManager.Instance.ResetWave();
    }
}
