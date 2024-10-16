using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct StatUpgradeUIInfo
{
    public int Level { get; private set; }
    public string Name { get; private set; }
    public float Value { get; private set; }
    public int Cost { get; private set; }

    public StatUpgradeUIInfo(int level, string name, float value, int cost)
    {
        Level = level;
        Name = name;
        Value = value;
        Cost = cost;
    }
}

public class UpgradeStatContainer : UIComponent
{
    [SerializeField]
    private Image _statImage;

    [SerializeField]
    private TextMeshProUGUI _level, _name, _value, _cost;

    [SerializeField] // Test
    private StatType _statType;

    public void Start()
    {
        UpdateUI();
    }

    public override void UpdateUI()
    {
        StatUpgradeUIInfo statUpgradeUIInfo = GameManager.Instance.GetPlayer().EntityStatController.GetStatUpgradeUIInfo(_statType);
        //_level.SetText(palyerStat.GetStatLevel(_statType).ToString());
        //_name.SetText(_statType.ToString());
        //_value.SetText(palyerStat.GetStatValue(_statType).ToString());

        _level.SetText($"Lv {statUpgradeUIInfo.Level.ToString()}");
        _name.SetText(statUpgradeUIInfo.Name);
        _value.SetText(statUpgradeUIInfo.Value.ToString());
        _cost.SetText(statUpgradeUIInfo.Cost.ToString());
    }
}
