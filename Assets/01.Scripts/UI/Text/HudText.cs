using DG.Tweening;
using TMPro;
using UnityEngine;

public class HudText : TextMeshPro
{
    private Vector3 _originPos;

    protected override void Awake()
    {
        base.Awake();

        _originPos = transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnHudText(Random.Range(10, 999));
        }
    }

    public void SpawnHudText(float damageValue)
    {
        transform.localPosition = _originPos;
        color = new Color(255, 255, 255, 255);
        SetText(damageValue.ToString());
        Vector2 targetPos = new Vector2(Random.Range(-2, 2f), 3f);
        transform.DOLocalJump(targetPos, 5f, 1, 1f);
        color = new Color(0,0,0,0);
    }
}