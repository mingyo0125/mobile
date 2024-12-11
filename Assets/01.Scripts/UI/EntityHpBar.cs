using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHpBar : MonoBehaviour
{
    [SerializeField]
    private Image _hpBar, _whiteBar;

    private float maxHp;

    public void UpdateMaxHp(float maxHp)
    {
        this.maxHp = maxHp;
    }

    public void ResetFillAmount()
    {
        _hpBar.fillAmount = 1;
    }

    public void SetHpbarValue(float curHp)
    {
        _hpBar.fillAmount = curHp / maxHp;

        // ��� �ٴ� �����̸� �ΰ� õõ�� ����
        DOTween.To(() => _whiteBar.fillAmount, x => _whiteBar.fillAmount = x, curHp / maxHp, 0.5f);
    }
}