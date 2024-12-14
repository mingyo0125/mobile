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

    private void OnEnable()
    {
        UpdateBossRushUI(curLevel);
    }

    private void Awake()
    {
        _bossRushUI = GetComponent<BossRushUI>();

        foreach (BossRushInfoSO infoSo in _bossRushInfoSos)
        {
            BossRushInfo bossRushInfo = infoSo.BossRushInfo;

            _bossRushInfo.Add(bossRushInfo.Level, bossRushInfo);
        }

        _bossRushUI.SetButtonEvents(ChangeLevel, EnterBossRush);
    }

    private void ChangeLevel(int level)
    {
        bool canChange = false;

        if (curLevel > level)
        {
            //바꾸려는 것보다 현재가 더 크면 (-)
            // 2 -> 1
            canChange = curLevel >= 2;
        }
        else
        {
            // 바꾸려는 것보다 현재가 더 작으면 (+)
            // 1 -> 2
            canChange = _bossRushInfoSos.Count > curLevel;
        }

        if (canChange)
        {
            UpdateBossRushUI(level);
        }
    }

    private void EnterBossRush(int level)
    {
        UIManager.Instance.RemoveTopUGUI();

        Debug.Log($"Enter {level}");
    }

    public void UpdateBossRushUI(int level)
    {
        if(!_bossRushInfo.TryGetValue(level, out BossRushInfo bossRushInfo))
        {
            Debug.LogError($"{level}BossRush is not Defined");
            return;
        }

        curLevel = level;
        
        _bossRushUI.UpdateBossRushUI(bossRushInfo);
    }

}
