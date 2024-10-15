using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStatContainer : UIComponent
{
    [SerializeField]
    private Image _statImage;

    [SerializeField]
    private TextMeshProUGUI _level, _name, _value, _cost;

    public override void UpdateUI()
    {
        //PlayerStat playerStat = GameManager.Instance.GetPlayerStat();
        //_level.SetText(playerStat.)
    }

}
