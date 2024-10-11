using UnityEngine;

public class UIManager : MonoSingleTon<UIManager>
{
    public void SpawnHudText(Transform parentTrm, string value, Color textColor)
    {
        Debug.Log(parentTrm);

        HudText _hudText = PoolManager.Instance.CreateObject("HudText") as HudText;
        _hudText.transform.SetParent(parentTrm);
        _hudText.SetPosition(parentTrm.position + new Vector3(0, 0.1f, 0));
        _hudText.SpawnHudText(value, textColor);
    }
}
