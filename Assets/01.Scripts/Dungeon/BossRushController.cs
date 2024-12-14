using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushController : MonoBehaviour
{
    [SerializeField]
    private List<BossRushInfoSO> _bossRushInfoSos = new List<BossRushInfoSO>();

    private Dictionary<int, BossRushInfo> _bossRushInfo = new Dictionary<int, BossRushInfo>();

    private BossRushUI _bossRushUI;

    private int curLevel = 1;

    private void Awake()
    {
        _bossRushUI = GetComponent<BossRushUI>();

        foreach (BossRushInfoSO infoSo in _bossRushInfoSos)
        {
            BossRushInfo bossRushInfo = infoSo.BossRushInfo;

            _bossRushInfo.Add(bossRushInfo.Level, bossRushInfo);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpdateBossRushUI(curLevel);
        }
    }

    private bool ChangeLevel(int level)
    {
        if (curLevel > level)
        {
            //바꾸려는 것보다 현재가 더 크면 (-)
            // 2 -> 1
            return level >= 2;
        }
        else
        {
            // 바꾸려는 것보다 현재가 더 작으면 (+)
            // 1 -> 2
            return _bossRushInfoSos.Count > level;

        }
    }

    public void UpdateBossRushUI(int level)
    {
        if(!_bossRushInfo.TryGetValue(level, out BossRushInfo bossRushInfo))
        {
            Debug.LogError($"{level}BossRush is not Defined");
            return;
        }

        _bossRushUI.UpdateBossRushUI(bossRushInfo, ChangeLevel);

        curLevel = level;
    }

}
