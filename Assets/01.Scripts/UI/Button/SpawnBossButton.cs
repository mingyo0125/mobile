using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossButton : UI_Button
{
    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach(Enemy enemy in enemies)
        {
            PoolManager.Instance.DestroyObject(enemy);
        }

        WaveManager.Instance.SpawnBossWarningPanel();
        
        transform.parent.gameObject.SetActive(false);
    }
}
