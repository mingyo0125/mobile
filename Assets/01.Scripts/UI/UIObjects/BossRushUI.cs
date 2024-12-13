using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossRushUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _rewardText;

    [SerializeField]
    private Image _appearBossImage;

    [SerializeField]
    private UI_Button _leftButton, _rightButton;

    [SerializeField]
    private UI_Button _enterButton;
}
