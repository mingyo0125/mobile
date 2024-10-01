using DG.Tweening;
using TMPro;
using UnityEngine;

public class HudText : TextMeshPro
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnHudText();
        }
    }

    public void SpawnHudText()
    {
        Vector2 targetPos = new Vector2(Random.Range(-2, 2f), 3f);
        transform.DOLocalJump(targetPos, 5f, 1, 1f);
    }
}