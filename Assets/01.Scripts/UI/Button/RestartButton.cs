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

        Object[] skills = FindObjectsByType(typeof(BaseSkill), FindObjectsSortMode.None);
        foreach (var skill in skills)
        {
            PoolManager.Instance.DestroyObject(skill as BaseSkill);
        }

        WaveManager.Instance.ReSetEnemies();
    }
}
